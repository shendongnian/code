    public IDictionary<string,int> getChampionships()
    {
         return Enum.GetNames(typeof(Camp))
                    .ToDictionary(item => item, item => (int)Enum.Parse(typeof(Camp), item)); 
    }
    
