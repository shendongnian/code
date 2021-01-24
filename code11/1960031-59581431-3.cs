    public class Prijem
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int BCode { get; set; }
        public string Name { get; set; }
        public string FirmName { get; set; }
        public string ItemCode { get; set; }
        public string Count { get; set; }
     }
