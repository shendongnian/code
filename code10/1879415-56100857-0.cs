    public bool AddACoin (int ID, String coinName, String coinNation, String coinStatus, int coinYear, int quantity, float value)
        {
            var jsonSerializer = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(path, true))
            {
                string json = streamReader.ReadToEnd();
                coins = JsonConvert.DeserializeObject<List<Coin>>(json);
                coins.Add(new Coin(ID, coinName, coinNation, coinStatus, coinYear, quantity, value));
                string newJson = JsonConvert.SerializeObject(coins);
                streamReader.Close();
                File.WriteAllText(path, newJson);
            }
                return true;
        }
