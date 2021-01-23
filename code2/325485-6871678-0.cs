    public  int CountProperty1
    {
        get
        {
            return GetCount(row.Property1);
        }
    }
    
    public  int CountProperty2
    {
        get
        {
            return GetCount(row.Property2);
        }
    }
    
    private int GetCount(object property)
    {
        int count = 0;
        foreach (var row in Data)
        {
            if(property == row.Property1)
            {
                count = count + row.Property1;
            }
            else if (property == row.Property2)
            {
                count = count + row.Property2;
            }
        }
        return count ;
    }
