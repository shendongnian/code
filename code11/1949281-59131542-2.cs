    public string GetTemperatureByStringParse(string inputJson)
    {
        string[] dataPairs = inputJson.Split(',');
        return dataPairs.FirstOrDefault(s => s.Contains("Temperature"))?.Split(':')[1].Trim();
    }
