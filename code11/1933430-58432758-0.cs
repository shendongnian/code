    public class App
    {
        public string ItemID { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public List<Report> Reports { get; set; }
    }
    
    public class Report
    {
        public string Reports_ItemID { get; set; }
        public string Reports_Path { get; set; }
        public string Reports_Name { get; set; }
    }
