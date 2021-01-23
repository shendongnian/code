    using (Stream responseStream = response.GetResponseStream())
    using (StreamReader reader = new StreamReader(responseStream))
    using (StreamWriter writer = new StreamWriter(filename))
    {
        int chunkSize = 1024;
        while (!reader.EndOfStream)
        {
            char[] buffer = new char[chunkSize];
            int count = reader.Read(buffer, 0, chunkSize);
            if (count != 0)
            {
                writer.Write(buffer, 0, count);
            }
        }
    }
