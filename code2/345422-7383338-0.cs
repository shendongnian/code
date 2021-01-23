    public static class Upload
    {
        private const string FileFieldNameDefault = "fileContent";
        public static WebResponse PostFile
            (Uri requestUri, NameValueCollection postData, Stream fileData, string fileName,
             string fileContentType, string fileFieldName, CookieContainer cookies,
             NameValueCollection headers)
        {
            ServicePointManager.Expect100Continue = false; 
            if (requestUri.Scheme == "https") 
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, err) => true;
            }
            var webRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            webRequest.Method = "POST";
            string boundary = "----------" + DateTime.Now.Ticks.ToString("x", CultureInfo.InvariantCulture);
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            string ctype;
            if (string.IsNullOrEmpty(fileContentType))
                fileContentType = TryGetContentType(fileName, out ctype)
                                    ? ctype
                                    : "application/octet-stream";
            fileFieldName = string.IsNullOrEmpty(fileFieldName) ? FileFieldNameDefault : fileFieldName;
            if (headers != null)
                foreach (string key in headers.AllKeys)
                {
                    var values = headers.GetValues(key);
                    if (values != null)
                        foreach (var value in values)
                            webRequest.Headers.Add(key, value);
                }
            if (cookies != null)
                webRequest.CookieContainer = cookies;
            var sbHeader = new StringBuilder();
            if (fileData != null)
            {
                var fileNameValue = string.Empty;
                if (string.IsNullOrEmpty(fileName) == false)
                    fileNameValue = string.Format(CultureInfo.InvariantCulture, "filename=\"{0}\"", Path.GetFileName(fileName));
                sbHeader
                    .AppendFormat("--{0}", boundary)
                    .AppendLine()
                    .AppendFormat("Content-Disposition: form-data; name=\"{0}\"; {1}", fileFieldName, fileNameValue)
                    .AppendLine()
                    .AppendFormat("Content-Type: {0}", fileContentType)
                    .AppendLine()
                    .AppendLine();
            }
            var sbFooter = new StringBuilder();
            sbFooter.AppendLine();
            if (postData != null)
                foreach (var key in postData.AllKeys)
                {
                    var values = postData.GetValues(key);
                    if (values != null)
                        foreach (var value in values)
                            sbFooter
                                .AppendFormat("--{0}", boundary)
                                .AppendLine()
                                .AppendFormat("Content-Disposition: form-data; name=\"{0}\"", key)
                                .AppendLine()
                                .AppendLine()
                                .Append(value)
                                .AppendLine();
                }
            sbFooter.AppendFormat("--{0}--\r\n", boundary);
            byte[] header = Encoding.UTF8.GetBytes(sbHeader.ToString());
            byte[] footer = Encoding.UTF8.GetBytes(sbFooter.ToString());
            long contentLength = header.Length + (fileData != null ? fileData.Length : 0) + footer.Length;
            webRequest.ContentLength = contentLength;
            using (var requestStream = webRequest.GetRequestStream())
            {
                requestStream.Write(header, 0, header.Length);
                if (fileData != null)
                {
                    var buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = fileData.Read(buffer, 0, buffer.Length)) != 0)
                        requestStream.Write(buffer, 0, bytesRead);
                }
                requestStream.Write(footer, 0, footer.Length);
                return webRequest.GetResponse();
            }
        }
        public static WebResponse PostFile
            (Uri requestUri, NameValueCollection postData, string fileName,
             string fileContentType, string fileFieldName, CookieContainer cookies,
             NameValueCollection headers)
        {
            using (var fileData = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                return PostFile(requestUri, postData, fileData,
                                fileName, fileContentType, fileFieldName, cookies,
                                headers);
        }
        private static bool TryGetContentType(string fileName, out string contentType)
        {
            try
            {
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type");
                if (key != null)
                {
                    foreach (string keyName in from keyName in key.GetSubKeyNames()
                                               let subKey = key.OpenSubKey(keyName)
                                               where subKey != null
                                               let subKeyValue = (string)subKey.GetValue("Extension")
                                               where string.IsNullOrEmpty(subKeyValue) == false
                                               where string.Compare(Path.GetExtension(fileName), subKeyValue, StringComparison.OrdinalIgnoreCase) == 0
                                               select keyName)
                    {
                        contentType = keyName;
                        return true;
                    }
                }
            }
            catch
            {
                // fail silently
                // TODO: rethrow registry access denied errors
            }
            contentType = string.Empty;
            return false;
        }
    }
