    public static bool DownloadFileMethod(HttpContext httpContext, string filePath, long speed)
    {
        // Many changes: mostly declare variables near use
        // Extracted duplicate references to HttpContext.Response and .Request
        // also duplicate reference to .HttpMethod
        // Removed try/catch blocks which hid any problems
        var response = httpContext.Response;
        var request = httpContext.Request;
        var method = request.HttpMethod.ToUpper();
        if (method != "GET" &&
            method != "HEAD")
        {
            response.StatusCode = 501;
            return false;
        }
        if (!File.Exists(filePath))
        {
            response.StatusCode = 404;
            return false;
        }
        // Stream implements IDisposable so should be in a using block
        using (var myFile = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            var fileLength = myFile.Length;
            if (fileLength > Int32.MaxValue)
            {
                response.StatusCode = 413;
                return false;
            }
            var lastUpdateTiemStr = File.GetLastWriteTimeUtc(filePath).ToString("r");
            var fileName = Path.GetFileName(filePath);
            var fileNameUrlEncoded = HttpUtility.UrlEncode(fileName, Encoding.UTF8);
            var eTag = fileNameUrlEncoded + lastUpdateTiemStr;
            var ifRange = request.Headers["If-Range"];
            if (ifRange != null && ifRange.Replace("\"", "") != eTag)
            {
                response.StatusCode = 412;
                return false;
            }
            long startBytes = 0;
            // Just guessing, but I bet you want startBytes calculated before
            // using to calculate content-length
            var rangeHeader = request.Headers["Range"];
            if (rangeHeader != null)
            {
                response.StatusCode = 206;
                var range = rangeHeader.Split(new[] {'=', '-'});
                startBytes = Convert.ToInt64(range[1]);
                if (startBytes < 0 || startBytes >= fileLength)
                {
                    // TODO: Find correct status code
                    response.StatusCode = (int) HttpStatusCode.BadRequest;
                    response.StatusDescription =
                        string.Format("Invalid start of range: {0}", startBytes);
                    return false;
                }
            }
            response.Clear();
            response.Buffer = false;
            response.AddHeader("Content-MD5", GetMD5Hash(filePath));
            response.AddHeader("Accept-Ranges", "bytes");
            response.AppendHeader("ETag", string.Format("\"{0}\"", eTag));
            response.AppendHeader("Last-Modified", lastUpdateTiemStr);
            response.ContentType = "application/octet-stream";
            response.AddHeader("Content-Disposition", "attachment;filename=" +
                                                        fileNameUrlEncoded.Replace("+", "%20"));
            var remaining = fileLength - startBytes;
            response.AddHeader("Content-Length", remaining.ToString());
            response.AddHeader("Connection", "Keep-Alive");
            response.ContentEncoding = Encoding.UTF8;
            if (startBytes > 0)
            {
                response.AddHeader("Content-Range",
                                    string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
            }
            // BinaryReader implements IDisposable so should be in a using block
            using (var br = new BinaryReader(myFile))
            {
                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                const int packSize = 1024*10; //read in block，every block 10K bytes
                var maxCount = (int) Math.Ceiling((remaining + 0.0)/packSize); //download in block
                for (var i = 0; i < maxCount && response.IsClientConnected; i++)
                {
                    response.BinaryWrite(br.ReadBytes(packSize));
                    response.Flush();
                    // HACK: Unexplained sleep
                    var sleep = (int) Math.Ceiling(1000.0*packSize/speed); //the number of millisecond
                    if (sleep > 1) Thread.Sleep(sleep);
                }
            }
        }
        return true;
    }
