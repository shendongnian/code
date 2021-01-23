    public class GenericReportInfo 
    {
        public string ReportName { get; set; }
        public string ReportFileName { get; set; }
        public IList<Parameter> Parameters { get; set; }
        public GenericReportInfo(
            string reportName,
            string reportFileName,
            IEnumerable<Parameter> parameters)
        {
            ReportName = reportName;
            ReportFileName = reportFileName;
            Parameters = new List<Parameter>(parameters);
        }
    }
    
    public class Parameter 
    {
        public string Name { get; set; }
    }
