    class Results
    {
        public ReportResult Invalid { get; set; }
        public ReportResult Valid { get; set; }
        public ReportResult Active { get; set; }
        public List<ReportResult> AllResults => new List<ReportResult>{Invalid,Valid,Active};
    }
