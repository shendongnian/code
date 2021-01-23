    //Sample 2
    StreamReader sr2 = new StreamReader(@"C:\Data.txt");
    using (sr2)
    {
        string s2 = sr2.ReadToEnd();
        //Do something with s2...
    }
    
    sr2.ReadToEnd() // possible to write, but accessing a disposed object.
