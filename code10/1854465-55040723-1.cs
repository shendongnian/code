    string inputtemplate = "00000000000000000000input0000000061306465643436000100000000000000input0000000000613064656434360001000000000000005bd0a47500000000000000000000000000000000";
    string wordtoreplace = "input";
    List<string> inputs = new List<string>() { "11antigeek11", "1antigeek11" };
    foreach(string s in inputs)
    {
        int inputindex = inputtemplate.IndexOf(wordtoreplace);
        if(inputindex < 0)
            Throw new Exception("Input not found");
        
        string tmp;
        
        if(s.Length < wordtoreplace.Length)
        {
            tmp = String.Concat(s, new String('0', wordtoreplace.Length - s.Length));
        }
        else if(s.Length > wordtoreplace.Length)
        {
            tmp = inputtemplate.Substring(inputindex, s.Length);
            if(tmp != String.Concat(wordtoreplace, new String('0', s.Length - wordtoreplace.Length)
                Throw new Exception("Input value is too long");
            else
                tmp = s;
        }
        
        inputtemplate = inputtemplate.Remove(inputindex, tmp.Length);
        inputtemplate = inputtemplate.Insert(inputindex, tmp);
    }
