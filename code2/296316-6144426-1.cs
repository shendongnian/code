    public void LoadData(string data, Action<BaseClass, string, MemoryStream> handler)
    {
        if (!string.IsNullOrEmpty(data))
        {
            byte[] dataAsArray = System.Text.Encoding.UTF8.GetBytes(data);
            MemoryStream stream = new MemoryStream(dataAsArray);
            handler(this, data, stream); // do something with it!
            DoLoadStream(stream);  // can still keep/use these if you want
            DoLoadDataLoaded(data);
        }
    }
