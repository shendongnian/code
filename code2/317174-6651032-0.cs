    StreamReader sr = new StreamReader(@"D:\ItemID.txt");
    try
    {
        string line = sr.ReadLine();
        while (line != null)
        {
            if (0 == string.Compare(line, item_id))
                return 1;
            line = sr.ReadLine();
        }
    }
    finally
    { 
        sr.Close();
    }
    return 0;
