    public IEnumerable<int> GetDataFromLines(string[] lines)
    { 
        //handle the output data
        List<int> data = new List<int>();
    
        foreach (string line in lines)
        {
            string[] seperators = new string[] { "|", "\"" };
        
            string[] results = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string result in results)
            {
                data.Add(int.Parse(result));
            }
        }
        return data;
    }
