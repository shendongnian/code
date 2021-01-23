    public class DR405Model
    {
        [DataType(DataType.Text)]
        public string TaxPayerId { get; set; }
        [DataType(DataType.Text)]
        public string ReturnYear { get; set; }
    
        public HttpPostedFileBase File { get; set; }
    }
