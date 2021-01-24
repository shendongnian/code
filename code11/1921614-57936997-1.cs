    [System.Serializable]
    public class AllData {
        public double bucketProg = 0;
        public double milk = 0;
        public double totalMilk = 0;
        public double milkPrice = 0;
        public double totalClicks = 0;
        public double coins = 0;
        public double totalCoins = 0;
        public double upgradeBucketCost = 10;
        public double qualityMilkCost = 1000;
        public double BucketLevel = 1;
        public double milkLevel = 1;
        public double multiplier = 1;
    }
    
    public class SaveSystem {
        AllData allData = new AllData();
        public void Save(AllData allData) {
    
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/allData.hey", FileMode.Create);
            bf.Serialize(file, allData);
            file.Close();
        }
        public AllData Load() {
    
            if (File.Exists(Application.persistentDataPath + "/allData.hey")) {
    
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/allData.hey", FileMode.Open);
                allData = (AllData)bf.Deserialize(file);
                file.Close();
                return allData;
            }
    
            return null;
        }
