    public bool AddACoin (int ID, String coinName, String coinNation, String coinStatus, int coinYear, int quantity, float value)
    {
        var jsonSerializer = new JsonSerializer();
    
        using (StreamWriter streamWriter = new StreamWriter(path, false))
        using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
        {
            string myJsonString = File.ReadAllText(path);
            coins = JsonConvert.DeserializeObject<List<Coin>>(myJsonString);
            coins.Add(new Coin(ID, coinName, coinNation, coinStatus, coinYear, quantity, value));
            jsonSerializer.Serialize(jsonWriter, coins.ToList());
        }
        return true;
    }
