    void Main()
    {
    	int iIntVal = ConvertTo<int>("10");
    	double dDoubleVal = ConvertTo<double>("10.42");
    }
    
    public T ConvertTo<T>(string val) where T: struct
    {
    	return (T) System.Convert.ChangeType(val, Type.GetTypeCode(typeof(T)));
    }
