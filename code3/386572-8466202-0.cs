    public DataSet GetData()
    {
        DataSet ds;
        // code to fetch data here
        return ds;
    }
    
    public void MethodThatUsesDataSet(DataSet ds)
    {
        // use dataset here
    }
    
    // call it like this:
    MethodThatUsesDataSet(GetData());
