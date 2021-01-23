    byte[] b = new byte[128];
    string sTitle;
    string sSinger;
    string sAlbum;
    string sYear;
    string sComm;
    FileStream fs = new FileStream(file, FileMode.Open);
    fs.Seek(-128, SeekOrigin.End);
    fs.Read(b, 0, 128);
    bool isSet = false;
    String sFlag = System.Text.Encoding.Default.GetString(b, 0, 3);
    if (sFlag.CompareTo("TAG") == 0)
    {
    System.Console.WriteLine("Tag   is   setted! ");
    isSet = true;
    }
    if (isSet)
    {
    //get   title   of   song; 
    sTitle = System.Text.Encoding.Default.GetString(b, 3, 30);
    System.Console.WriteLine("Title: " + sTitle);
    //get   singer; 
    sSinger = System.Text.Encoding.Default.GetString(b, 33, 30);
    System.Console.WriteLine("Singer: " + sSinger);
    //get   album; 
    sAlbum = System.Text.Encoding.Default.GetString(b, 63, 30);
    System.Console.WriteLine("Album: " + sAlbum);
    //get   Year   of   publish; 
    sYear = System.Text.Encoding.Default.GetString(b, 93, 4);
    System.Console.WriteLine("Year: " + sYear);
    //get   Comment; 
    sComm = System.Text.Encoding.Default.GetString(b, 97, 30);
    System.Console.WriteLine("Comment: " + sComm);
    }
    System.Console.WriteLine("Any   key   to   exit! ");
    System.Console.Read();
