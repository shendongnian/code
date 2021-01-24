        public void Get()
        {
            var path = @"C:\temporal\bigfile.mp4";
            var response = HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.AddHeader("Content-Disposition", "inline; filename=" + HttpUtility.UrlPathEncode(path));
            response.ContentType = "text/plain";
            response.AddHeader("Content-Length", new FileInfo(path).Length.ToString());
            response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
                
            TransmitFileWithLimit(path, 10000);
            File.Delete(path);
        }
        public void TransmitFileWithLimit(string path, int limit)
        {
            var buffer = new byte[limit];
            var offset = 0;
            var response = HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            using (var fileStream = File.OpenRead(path))
            {
                var lengthStream = fileStream.Length;
                while (offset < lengthStream)
                {
                    var lengthBytes = fileStream.Read(buffer, 0, limit);
                    var chars = System.Text.Encoding.ASCII.GetString(buffer, 0, lengthBytes).ToCharArray();
                    response.Write(chars, 0, lengthBytes);
                    offset += lengthBytes;
                }
            }
            response.Flush();
            response.End();
        }
