     using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
               Console.WriteLine (client.DownloadString("http://www.maxima.fm/51Chart/"));
            }
