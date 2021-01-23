    class JsonResult
    {
        public string dola { get; set; }
        public Data data { get; set; }
        public class Data
        {
            public List<House> house { get; set; }
        }
        public class House
        {
            public string dola { get; set; }
            public HouseData data { get; set; }
        }
        public class HouseData
        {
            public string owner { get; set; }
            public int price {get;set;}
            public Uri url {get;set;}
            public string message {get;set;}
            public bool @checked {get;set;}
        }
    }
