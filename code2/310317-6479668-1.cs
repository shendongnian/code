    foreach (string line in lines)
    {
        line = "1234|1234567|123\"12345\"12\"123456";
        //string format = "[%f1%]|[%f2%]|[%f3%]\"[%f4%]\"[%f5%]\"[%f6%]";
    
        string[] seperators = new string[] { "|", "\"" };
    
        string[] results = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
        
        //handle the output data like:
        List<int> data = new List<int>();
        foreach (string result in results)
        {
            data.Add(int.Parse(result));
        }
        
    }
