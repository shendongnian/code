    public class CoinsManager
    {
        public List<Coin> Coins { get; set; }
        public string FilePath { get; set; }
        public CoinsManager(string filePath)
        {
            FilePath = filePath;
            Coins = new List<Coin>();
        }
        public void LoadCoins()
        {
            if (File.Exists(FilePath))
            {
                //If file exists, but empty, save empty settings to it
                if (new FileInfo(FilePath).Length == 0)
                {
                    SaveSettings();
                }
                else
                {
                    //Read json from file
                    using (StreamReader r = new StreamReader(FilePath))
                    {
                        string json = r.ReadToEnd();
                        //Convert json to list
                        Coins = JsonConvert.DeserializeObject<List<Coin>>(json);
                    }
                }
            }
            else
            {
                //Create file
                File.Create(FilePath).Close();
                //Wait for filesystem to create file
                while (!File.Exists(FilePath))
                {
                    System.Threading.Thread.Sleep(100);
                }
                //Save empty settings to file
                SaveSettings();
            }
        }
        public void SaveSettings()
        {
            string json = JsonConvert.SerializeObject(Coins);
            File.WriteAllText(FilePath, json);
        }
        //Can save or update passed coin
        public void SaveCoin(Coin coin)
        {
            //Select old coin
            var oldCoin = Coins.Where(c => c.ID == coin.ID).FirstOrDefault();
            //If there was no old coin, get last existing coin id, or zero if Coins list is empty
            if (oldCoin == null)
            {
                int lastId;
                if (Coins.Count != 0)
                    lastId = Coins.Count - 1;
                else
                    lastId = 0;
                coin.ID = lastId + 1;
                Coins.Add(coin);
            }
            else
            {
                int index = Coins.IndexOf(oldCoin);
                Coins[index] = coin;
            }
        }
        public void DeleteCoin(Coin coin)
        {
            Coins.RemoveAll(c => c.ID == coin.Id);
        }
    }
