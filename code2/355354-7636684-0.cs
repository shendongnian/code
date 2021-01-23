    for( int 1= 0;i< filestoextract.count;1++)
    {
        string extractname = filestoextract[i].ToString();
        string ID = extractname.substring(0, extractname.IndexOf(','));
        string Date = extractname.substring(extractname.IndexOf(','));
        Console.WriteLine(ID + Date);
    }
