        Dictionary<string, string> myDict = new Dictionary<string, string>(); 
  
        // Adding key/value pairs in myDict 
        myDict.Add("text1", ""); 
        myDict.Add("text2", ""); 
        myDict.Add("text3", ""); 
        myDict.Add("text4", ""); 
  
        if (myDict.ContainsKey(stringParam)) 
            Console.WriteLine("It matched"); 
