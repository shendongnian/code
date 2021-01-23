        // for each file
        string contents = ""; // read in the whole file into this variable
        foreach (string line in contents.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        {
            string[] values = line.Split('|'); 
            // do something with the values, accessing the first one as values[0] etc
        }
