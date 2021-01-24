    [Serializable]
    public class Data
    {
        public string id;
        public string name;
        public string country;
        public Coord coord;
    }
    
    [Serializable]
    public class Coord
    {
        public float lon;
        public float lat;
    }
    
    Data myData = JsonUtility.FromJson<Data>(json);
