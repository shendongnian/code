    private static object _lock = new object();
    
    public method AnotherDataClass Convert(MyDataClass target)
    {
        lock(_lock)
        {
             AnotherDataClass val = new AnotherDataClass();
             // read infomration from target
             // put information into val; 
             return val;
        }
    }
