    private void DoSplit(string str)
    {
        str += str.Trim() + " ";
        string patterns = @"\w+:([\w+\s*])+[^!\w+:]";
        var r = new System.Text.RegularExpressions.Regex(patterns);
        var ms = r.Matches(str);
        foreach (System.Text.RegularExpressions.Match item in ms)
        {
            string[] s = item.Value.Split(new char[] { ':' });
            //Do something
        }
    }
