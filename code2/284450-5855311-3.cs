    [Test]
    public void CanStreamMP3Radio()
    {
        string url = @"http://radio.reaper.fm/stream/";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
        {
            int total = 0;
            byte[] buffer = new byte[1024];
    
            var networkStream = resp.GetResponseStream();
            do
            {
                int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                Console.WriteLine("{0} bytesRead", bytesRead);
                total += bytesRead;
            } while (total < 16384);
            Console.WriteLine("Cleaning up HttpWebResponse...");
            req.Abort();
        }
        Console.WriteLine("Finished");
    }
