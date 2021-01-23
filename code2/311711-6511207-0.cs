    public void ProcessFile(string filename)
    {
        string line = null;
        string nextLine = null;
        using (StreamReader reader = new StreamReader(filename))
        {
            line = reader.ReadLine();
            nextLine = reader.ReadLine();
            do
            {
                if (line != null)
                {
                    // Process line (possibly using nextLine).
                }
                line = nextLine;
                nextLine = reader.ReadLine();
            } while (line != null || nextLine != null);
        }
    }
