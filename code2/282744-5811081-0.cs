    [Serializable]
    public class Config
    {
        public int ValueOne { get; set; }
        public string ValueTwo { get; set; }
        public int[] LotsOfValues { get; set; }
        public List<FurtherConfig> Other { get; set; }
    }
    
    [Serializable]
    public class FurtherConfig 
    {
        public int Value { get; set; }
    }
