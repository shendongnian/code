    public void Method(int val)
    {
        GenericMethod(val);
    }
    public void Method(double val)
    {
        GenericMethod(val);
    }
    private void GenericMethod<T>(T val) where T:struct
    {
    }
