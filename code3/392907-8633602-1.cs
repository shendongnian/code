        protected string Injection(string str)
    {
        //Checks for remarks, new commands and string inputs.
        if (str.Contains("--"))
            str.Remove(str.IndexOf('-'), 1);
        else if (str.Contains(";"))
            str.Remove(str.IndexOf(';'),1);
        return str.Replace("'","''");
        
    }
