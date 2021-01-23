    string contents = String.Empty;
    using (FileStream fs = File.Open("path", FileMode.OpenRead))
    using (StreamReader reader = new StreamReader(fs))
    {
    	contents = reader.ReadToEnd();
    }
    
    if (contents.Length > 0)
    {
    	string[] lines = contents.Split(new char[] { '\n' });
    	Dictionary<string, string> mysettings = new Dictionary<string, string>();
    	foreach (string line in lines)
    	{
    		string[] keyAndValue = line.Split(new char[] { '=' });
    		mysettings.Add(keyAndValue[0].Trim(), keyAndValue[1].Trim());
    	}
    
    	string test = mysettings["USERID"]; // example of getting userid
    }
