    public class MySpecificException: Exception
    {
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }        
        public bool DatabaseError { get; set; }
        public string DatabaseMessage { get; set; }
        public Exception ex { get; set; }
    }
