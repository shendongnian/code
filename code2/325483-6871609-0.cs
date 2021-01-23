    public  int CountProperty1
    {
        get
        {
            return CountProperty(r => r.Property1);
        }
    }
    public  int CountProperty2
    {
        get
        {
            return CountProperty(r => r.Property2);
        }
    }
    private int CountProperty(Func<Row,int> countSelector)
    {
         int count = 0;
         foreach (var row in Data)
         {
             count = count + countSelector(row);
         }
         return count ;
    }
