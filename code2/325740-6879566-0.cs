    public string Something (IInterface obj)
    {
        return foo ((Class1)obj); 
        OR // There's no way compiler to know with method to call.
        return foo ((Class2)obj); 
    }
    public string foo (Class1 bar)
    {
        return "Class1";
    }
    public string foo (Class2 bar)
    {
        return "Class2";
    }
