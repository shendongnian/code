    void Main()
    {
    	var foo = RetNum<decimal>();
    	foo.Dump();
    }
    
    public static T RetNum<T>()
    {
    	return (T)Convert.ChangeType(1.9d, typeof (T));
    }
