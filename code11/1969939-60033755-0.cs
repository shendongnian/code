    public class TaxCertificateMailing
    {
        public TaxCertificateMailing()
        {
            Reports = new HashSet<Report>();
        }
        public int SelectedReportID { get; set; } 
        public ICollection<Report> Reports { get; set; }
    }
    public class Report
    {
        public string Text { get; set; }
        public int ID { get; set; }
    }
