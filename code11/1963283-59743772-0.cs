    public class someDTO
    {
        public int Id { get; set; }
        public int AuftragId { get; set; }
        public string Typ { get; set; }
        public decimal KundeBrutto { get; set; }
        public decimal KundeNetto { get; set; }
        public decimal KundeMwSt { get; set; }
        public decimal FahrerBrutto { get; set; }
        public decimal FahrerNetto { get; set; }
        public decimal FahrerMwSt { get; set; }
        public decimal MwStSatz { get; set; } = (decimal)0.19;
        public string MwStLand { get; set; } = "DE";
        public string FileName { get; set; }
        public string FileUrl { get; set; }
    }
