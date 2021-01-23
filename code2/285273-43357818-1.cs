    [System.Data.Linq.Mapping.Table(Name = "HistoricCommand")]
    public class DboHistoricCommand
    {
        [System.Data.Linq.Mapping.Column(Name = "HistoricCommandId", IsPrimaryKey = true)]
        public int HistoricCommandId { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "PHCloudSoftwareInstanceId", IsPrimaryKey = true)]
        public int PHCloudSoftwareInstanceId { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "CommandType", IsPrimaryKey = false)]
        public int CommandType { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "InitiatedDateTime", IsPrimaryKey = false)]
        public DateTime InitiatedDateTime { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "CompletedDateTime", IsPrimaryKey = false)]
        public DateTime CompletedDateTime { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "WasSuccessful", IsPrimaryKey = false)]
        public bool WasSuccessful { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "Message", IsPrimaryKey = false)]
        public string Message { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "ResponseData", IsPrimaryKey = false)]
        public string ResponseData { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "Message_orig", IsPrimaryKey = false)]
        public string Message_orig { get; set; }
    
        [System.Data.Linq.Mapping.Column(Name = "Message_XX", IsPrimaryKey = false)]
        public string Message_XX { get; set; }
    
    }
