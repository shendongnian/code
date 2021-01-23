    try
    {
        using (StreamReader sr = new StreamReader("TestFile.txt"))
        {
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                // convert line to Hex and then format with .ToString("X2")
            }
        }
    }
    catch
    {
        // handle error
    }
