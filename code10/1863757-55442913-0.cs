    public class Product
    {
        public string license { get; set; }
        public string carType { get; set; }
        public string contract { get; set; }
        public int amounttoCurrent { get; set; }
    }
    
    public class Datum
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Product> product { get; set; }
    }
    
    public class ReturnedData
    {
        public List<Datum> data { get; set; }
    }
    
    public class RootObject
    {
        public ReturnedData returned_data { get; set; }
    }
