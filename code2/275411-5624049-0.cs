    public class MyViewModel
    {
        public string DisplayUser { get; set; }
        public string ActiveIndicationsUserFullname { get; set; }
        public string Company { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime TimeOpened { get; set; }
        public string TrxId { get; set; }
    }
