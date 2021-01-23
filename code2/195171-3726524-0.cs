    //RegEx: ^([A-Z\"\,]+)[\"\,\s]+([A-Z\"\,]+)$
        string pattern = "^([A-Z\"\\,]+)[\"\\,\\s]+([A-Z\"\\,]+)$";
        System.Text.RegularExpressions.Regex Reg = new System.Text.RegularExpressions.Regex(pattern);
    
        string MyInput;
    
        MyInput = "\"HELLO\",\"WORLD\"";
        MyInput = "\"HELL\"O\"\",WORLD\"";
        MyInput = "\"HELL,O\",\"WORLD\"";
    
        string First;
        string Second;
    
        if (Reg.IsMatch(MyInput))
        {
            string[] result;
            result = Reg.Split(MyInput);
    
            First = result[1].Replace("\"","").Replace(",","");
            Second = result[2].Replace("\"","").Replace(",","");
        }
