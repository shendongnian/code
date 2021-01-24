    public Data GetData(string textLine)
    {
        var split = textLine.Split(new char[] {':'});
        var data = JsonSerializer.DeserializeObject<Data>(split[1]);
        return data;
    }
