    [System.Serializable]
    public class SpinResult
    {
        public string type;
        public string id;
        public Attributes attributes;
    }
    [System.Serializable]
    public class Attributes
    {
        public string server_seed;
        public string client_seed;
        public int result;
    }
