    //from another function
    string[] inputList = new string[] { "5", "+", "6", "+", "9", "-", "8", "+", "1" };
    string result = JoinList(inputList);
    //function to join list
    public string JoinList(string[] inputList){
        if(inputList.Length == 0)
            return "";
        List<string> list = new List<string>();
    
        int start = 0;
        if (string.IsNullOrEmpty(inputList[0]))
            start = 2;
    
        for (int i = start; i < inputList.Length; i++)
        {
            string s = inputList[i];
    
            if (string.IsNullOrEmpty(s))
            {
                if (list.Count > 0)
                    list.RemoveAt(list.Count - 1);
                continue;
            }
    
            list.Add(s);
        }
    
        return string.Join("", list);
    }
