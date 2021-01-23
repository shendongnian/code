                byte[] buffer = new byte[4096];
                using (Stream s = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int bytes;
                    while ((bytes = s.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Response.OutputStream.Write(buffer, 0, bytes);
                    }
                }
                Response.Flush();
