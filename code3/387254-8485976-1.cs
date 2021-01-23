    public List<int> GetYears()
    {
        var years = new List<int>();
    
        //create the reader
        while(reader.Read())
        {
            years.Add(reader.GetInt32(0));
        }
    
        return years;
    }
