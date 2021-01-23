    string str = "Sample Text";
    
    		List<string> lst = new List<string>();
    		while (str.Length > 500)
    		{
    			var temp = str.Substring(0, 500);
    			str = str.Remove(0, temp.Length);
    			lst.Add(temp);
    		}
    
    		lst.Add(str);
    
    		string[] arrayString = lst.ToArray();
    		Console.ReadLine();
