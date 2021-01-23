    using (StreamReader reader = File.OpenText("Path\to\your\file"))
    {
        string line = null;
        while ((line = reader.ReadLine()) != null)
        {
            try
            {
                ProcessLine(line);
            }
            catch { /* Ignore exceptions */ }
        }
    }
