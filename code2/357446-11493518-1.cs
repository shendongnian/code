    // This is set up once (durinig object initialization) and
    // evaluated once (the first time _datFileName.Value is accessed)
    private Lazy<string> _datFileName = new Lazy<string>(() =>
        {
            string filename = null;
            //Insert initialization code here to determine filename
            return filename;
        });
    // The other 3 properties are derived from this one.
    // Ends in .dat
    public string DatFileName
    {
        get { return _datFileName.Value; }
        private set { _datFileName = new Lazy<string>(() => value); }
    }
    private string DatFileBase
    {
        get { return Path.GetFileNameWithoutExtension(DatFileName); }
    }
    public string MicrosoftFormatName
    {
        get { return DatFileBase + "_m.fmt"; }
    }
    public string OracleFormatName
    {
        get { return DatFileBase + "_o.fmt"; }
    }
