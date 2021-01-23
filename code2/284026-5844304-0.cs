    using System;
    using System.IO;
    using System.Net;
    static class Program
    {
        static void Main()
        {
            string url = "http://www.uakron.edu/dotAsset/1265971.pdf", localPath = "1265971.pdf";
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            req.Headers.Add("Accept-Encoding","gzip,deflate");
            if(File.Exists(localPath))
                req.IfModifiedSince = File.GetLastWriteTimeUtc(localPath);
            try
            {
                using (var resp = req.GetResponse())
                {
                    int len;
                    checked
                    {
                        len = (int)resp.ContentLength;
                    }
                    using (var file = File.Create(localPath))
                    using (var data = resp.GetResponseStream())
                    {
                        byte[] buffer = new byte[4 * 1024];
                        int bytesRead;
                        while (len > 0 && (bytesRead = data.Read(buffer, 0, Math.Min(len, buffer.Length))) > 0)
                        {
                            len -= bytesRead;
                            file.Write(buffer, 0, bytesRead);
                        }
                    }
                }
                Console.WriteLine("New version downloaded");
            }
            catch (WebException ex)
            {
                if (ex.Response == null || ex.Status != WebExceptionStatus.ProtocolError)
                    throw;
                Console.WriteLine("Not updated");
            }
        }
    }
