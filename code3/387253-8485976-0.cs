    public List<int> GetYears()
    {
         var years = new List<int>();
    
        while(reader.HasNext())
        {
            years.Add(reader.GetInt(0));
        }
    
        return years;
    }
