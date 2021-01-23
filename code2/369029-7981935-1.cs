    public class PersonMetaData
    {
        [Required(ErrorMessage = "nima", AllowEmptyStrings = false)]
        public object ProductName { set; get; }
    
        [Range(minimum: 10, maximum: 100, ErrorMessage = "NIIMMMAA")]
        public object ProductID { set; get; }
    }
