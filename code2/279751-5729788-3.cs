    public static void Main()
    {
        int i = 1;
        PropertyRetrievalClass obj = new PropertyRetrievalClass();
        Delegate del = Delegate.CreateDelegate(
            typeof(PropertyRetrievalClass.getProperty), 
            obj, 
            "get_Chart_" + i.ToString());
        string output =  (string)del.DynamicInvoke("asldkl");
    }
