    string filePath = @"c:\temp\test.txt";
    string line; 
    
    Dictionary<string, int> dictAcculumator = new Dictionary<string,int>();
    
    if (File.Exists( filePath ))
    {
        using (StreamReader file = new StreamReader( filePath )){
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains('|')){
                        string[] items = line.Split('|');
                        int count;
                        string item = items[1];
                        if (int.TryParse(items[1], out count)){
                            if (dictAcculumator.ContainsKey(item)){
                                dictAcculumator[items[0]] += count;
                            }
                            else{
                                dictAcculumator.Add(items[0], count);
                            }
                        }
                    }
                }
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        } 
    }
    
    StringBuilder sb = new StringBuilder();
    foreach (string key in dictAcculumator.Keys)
    {
        //alternatively write to text file
        sb.AppendFormat("{0}|{1}\r\n", key, dictAcculumator[key].ToString());
    }
    
    Console.Write(sb.ToString());
