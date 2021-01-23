    static string[] StringToArray(string str)
    {
        Regex reg = new Regex(@"^\[(.*)\]$");
        Match match = reg.Match(str);
        if (!match.Success)
            return null;
        str = match.Groups[1].Value;
        List<string> list = new List<string>();
        reg = new Regex(@"\[[^\[\]]*(((?'Open'\[)[^\[\]]*)+((?'-Open'\])[^\[\]]*)+)*(?(Open)(?!))\]");
        Dictionary<string, string> dic = new Dictionary<string, string>();
        int index = 0;
        str = reg.Replace(str, m =>
        {
            string temp = "ojlovecd" + (index++).ToString();
            dic.Add(temp, m.Value);
            return temp;
        });
        string[] result = str.Split(',');
        for (int i = 0; i < result.Length; i++)
        {
            string s = result[i].Trim();
            if (dic.ContainsKey(s))
                result[i] = dic[s].Trim();
            else
                result[i] = s;
        }
        return result;
    }
