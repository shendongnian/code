    public form1()
    {
        InitializeComponent();
    
        System.Net.WebClient Client = new WebClient();
        Stream strm = Client.OpenRead("http://www.csharpfriends.com");
        StreamReader sr = new StreamReader(strm);
        string line;
        do
        {
            line = sr.ReadLine();
            listbox1.Items.Add(line);
        }
        while (line !=null);
        strm.Close();
    }
