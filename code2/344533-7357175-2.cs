    public void DoWork(Stream input)
    {
        StreamReader sr = new StreamReader(input);
        string s = sr.ReadToEnd();
        sr.Dispose();
        NameValueCollection qs = HttpUtility.ParseQueryString(s);
        string firstName = qs["firstName"];
        string lastName = qs["lastName"];
    }
