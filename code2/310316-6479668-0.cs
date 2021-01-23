    foreach (string line in lines)
    {
        line = "1234|1234567|123\"12345\"12\"123456";
        //string format = "[%f1%]|[%f2%]|[%f3%]\"[%f4%]\"[%f5%]\"[%f6%]";
    
        string[] seperators = new string[] { "|", "\"" };
    
        string[] results = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string output in results)
        { /*handle the output data*/}
        
    }
