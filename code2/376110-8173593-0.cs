        public static string ExecuteRequestReadToEnd(this WebRequest req)
        {
            var resp = req.GetResponse();
            using (var resps = resp.GetResponseStream())
            {
                var buffer = new byte[16 * 1024];
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = resps.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    var content = ms.ToArray();
                    return Encoding.UTF8.GetString(content, 0, content.Length);
                }
            }
        }
