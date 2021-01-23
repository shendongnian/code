    public static void MyMethod(List<AnyClass> list)
    {
        foreach (var obj in list)
        {
            MyMethod(obj);
        }
    }
    public static void MyMethod(AnyClass single)
    {
        //work with single instance    
    }
