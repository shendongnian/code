    public class Datum
    {
        public string ID { get; set; }
        public string Type_ID { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        public string Insert_User { get; set; }
        public string Insert_Date { get; set; }
        public string Update_User { get; set; }
        public string Update_Date { get; set; }
    }
    
    public class Response
    {
        public string message { get; set; }
        public List<Datum> data { get; set; }
    }
    
    public class RootObject
    {
        public bool success { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
    }
