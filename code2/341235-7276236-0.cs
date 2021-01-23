    string line = null;
    using (System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt"))
    {
        while ((line = file.ReadLine()) != null)
        {
            if (!line.StartsWith(";"))
            {
                // do thomething
            }
        }
    }
