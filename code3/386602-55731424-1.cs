    public class FileManager
    {
        public static void SaveFile(HttpListenerRequest request, string savePath)
        {
            var tempFileName = Path.Combine(savePath, $"{DateTime.Now.Ticks}.tmp");
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            var (res, fileName) = SaveTmpFile(request, tempFileName);
            if (res)
            {
                var filePath = Path.Combine(savePath, fileName);
                var fileDir = filePath.Substring(0, filePath.LastIndexOf(Path.DirectorySeparatorChar));
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.Move(tempFileName, filePath);
            }
        }
        private static (bool, string) SaveTmpFile(HttpListenerRequest request, string tempFileName)
        {
            var enc = request.ContentEncoding;
            var boundary = GetBoundary(request.ContentType);
            var input = request.InputStream;
            byte[] boundaryBytes = enc.GetBytes(boundary);
            var boundaryLen = boundaryBytes.Length;
            using (FileStream output = new FileStream(tempFileName, FileMode.Create, FileAccess.Write))
            {
                var buffer = new byte[1024];
                var len = input.Read(buffer, 0, 1024);
                var startPos = -1;
                // Get file name and relative path
                var strBuffer = Encoding.Default.GetString(buffer);
                var strStart = strBuffer.IndexOf("fileNameWithPath") + 21;
                if (strStart < 21)
                {
                    Logger.LogError("File name not found");
                    return (false, null);
                }
                var strEnd = strBuffer.IndexOf(boundary, strStart) - 2;
                var fileName = strBuffer.Substring(strStart, strEnd - strStart);
                fileName = fileName.Replace('/', Path.DirectorySeparatorChar);
                // Find start boundary
                while (true)
                {
                    if (len == 0)
                    {
                        Logger.LogError("Find start boundary not found");
                        return (false, null);
                    }
                    startPos = IndexOf(buffer, len, boundaryBytes);
                    if (startPos >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                        len = input.Read(buffer, boundaryLen, 1024 - boundaryLen);
                    }
                }
                // Advance to data
                var foundData = false;
                while (!foundData)
                {
                    while (true)
                    {
                        if (len == 0)
                        {
                            Logger.LogError("Preamble not Found");
                            return (false, null);
                        }
                        startPos = Array.IndexOf(buffer, enc.GetBytes("\n")[0], startPos);
                        if (startPos >= 0)
                        {
                            startPos++;
                            break;
                        }
                        else
                        {
                            // In case read in line is longer than buffer
                            len = input.Read(buffer, 0, 1024);
                        }
                    }
                    var currStr = Encoding.Default.GetString(buffer).Substring(startPos);
                    if (currStr.StartsWith("Content-Type:"))
                    {
                        // Go past the last carriage-return\line-break. (\r\n)
                        startPos = Array.IndexOf(buffer, enc.GetBytes("\n")[0], startPos) + 3;
                        break;
                    }
                }
                Array.Copy(buffer, startPos, buffer, 0, len - startPos);
                len = len - startPos;
                while (true)
                {
                    var endPos = IndexOf(buffer, len, boundaryBytes);
                    if (endPos >= 0)
                    {
                        if (endPos > 0) output.Write(buffer, 0, endPos - 2);
                        break;
                    }
                    else if (len <= boundaryLen)
                    {
                        Logger.LogError("End Boundaray Not Found");
                        return (false, null);
                    }
                    else
                    {
                        output.Write(buffer, 0, len - boundaryLen);
                        Array.Copy(buffer, len - boundaryLen, buffer, 0, boundaryLen);
                        len = input.Read(buffer, boundaryLen, 1024 - boundaryLen) + boundaryLen;
                    }
                }
                return (true, fileName);
            }
        }
        private static int IndexOf(byte[] buffer, int len, byte[] boundaryBytes)
        {
            for (int i = 0; i <= len - boundaryBytes.Length; i++)
            {
                var match = true;
                for (var j = 0; j < boundaryBytes.Length && match; j++)
                {
                    match = buffer[i + j] == boundaryBytes[j];
                }
                if (match)
                {
                    return i;
                }
            }
            return -1;
        }
        private static string GetBoundary(string ctype)
        {
            return "--" + ctype.Split(';')[1].Split('=')[1];
        }
    }
