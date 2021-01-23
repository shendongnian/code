    int BYTES_TO_READ = 1000;
    var buffer = new byte[BYTES_TO_READ];
    
    using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
    {
        using (Stream sm = resp.GetResponseStream())
        {
            int totalBytesRead = 0;
            int bytesRead;
            do
            {
                // You have to do this in a loop because there's no guarantee that
                // all the bytes you need will be ready when you call.
                bytesRead = sm.Read(buffer, totalBytesRead, BYTES_TO_READ-totalBytesRead);
                totalBytesRead += bytesRead;
            } while (totalBytesRead < BYTES_TO_READ);
        }
    }
