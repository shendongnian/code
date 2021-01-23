    using (TextReader reader = File.OpenText(filename))
    {
        string line = null; // Need to read to start with
        while (true)
        {
            if (line == null)
            {
                line = reader.ReadLine();
                // Check for end of file...
                if (line == null)
                {
                    break;
                }
            }
            if (line.Contains("Magic category"))
            {
                string lastLine = line;
                line = reader.ReadLine(); // Won't read again next iteration
            }
            else
            {
                // Process line as normal...
                line = null; // Need to read again next time
            }
        }
    }
