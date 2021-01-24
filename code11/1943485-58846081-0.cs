    public Data GetData(string textLine)
    {
        var split = textLine.Split(new [] { ':'});
        var data = JsonSerializer.DeserializeObject<Data>(split[0]);
        return data;
    }
