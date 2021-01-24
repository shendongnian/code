    public static class HttpResponseExtensions
    {
        public static void TransmitFileWithLimit(this HttpResponse response, string path, int limit)
        {
            var buffer = new byte[limit];
            var offset = 0;
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
    }
