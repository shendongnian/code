        public class ResponseModel
        {
          public string responseStatus { get; set; }
          public ResponseDetail responseDetails { get; set; }
    
          public List<DataModel> data = new List<DataModel>();
        }
        public class ResponseDetail
        {
          public int limit { get; set; }
          public int offset { get; set; }
          public int size { get; set; }
          public int total { get; set; }
        }
    
        public class DataModel
        {
          [JsonProperty(PropertyName = "tbl.col")]
          public string tbl_col { get; set; }
        }
