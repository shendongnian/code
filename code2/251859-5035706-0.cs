    public class Data
    {
        public int Maat_id { get; set; }
        public string Maat { get; set; }
    }
    
    public class MyModel
    {
        public Dictionary<int, Data> DataToJohnson { get; set; }
    }
