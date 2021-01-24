    [System.Serializable]
    public class TrainJsonResponse
    {
        public TrainServices[] trainServices;   
    }
    
    [System.Serializable]
    public class TrainServices
    {
        public Origin[] origin;
        public string std;
        public string etd;
    }
    
    [System.Serializable]
    public class Origin
    {
        public string locationName;
    }
