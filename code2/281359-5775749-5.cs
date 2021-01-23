    string line = null;
    using (var reader in new StreamReader(filename))
    {
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Contains(searchTarget))
            {   // found it!
                // do something...
                break; // then stop
            }
        }
    }
