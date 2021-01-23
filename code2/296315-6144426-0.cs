    public event Action<BaseClass, string> DataLoaded;
    
    protected virual void DoLoadDataLoaded(string data)
    {
        var e = DataLoaded;
        if(null != e)
            e(this, data);
    }
    
    protected virtual void DoLoadStream(MemoryStream stream)
    {
        Chart1.Serializer.Load(stream);
    }
    
    public void LoadData(string data)
    {
        if (!string.IsNullOrEmpty(data))
        {
            byte[] dataAsArray = System.Text.Encoding.UTF8.GetBytes(data);
            MemoryStream stream = new MemoryStream(dataAsArray);
            DoLoadStream(stream);
            DoLoadDataLoaded(data);
        }
    }
