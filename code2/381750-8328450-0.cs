    Uri tempUri = new Uri("http://microsoft.com/Default.aspx?IsMonkeyBusiness=true&Name=Daniel&Test=");
    string sQuery = tempUri.Query;
    NameValueCollection qscoll = HttpUtility.ParseQueryString(sQuery);
    foreach (string s in qscoll)
        foreach (string v in qscoll.GetValues(s))
            if (!(v=="")) Console.WriteLine("{0}",v);
    Console.ReadLine();
