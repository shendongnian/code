    public class StatReportDataItems
    {
    	public StatReportDataItems()
    	{
    		NumData = new List<double>();
    	}
    	
        public string Label { get; set; }
    
        public IEnumerable<double> NumData { get; set; }
    }
    public List<StatReportDataItems> GetReport888()
    {
        var query = from rv in ProcessDB.Report888Views
                    select new StatReportDataItems
                    {
                        Label = rv.Label,
                        NumData = new List<double> { rv.NumData1, rv.NumData2, rv.NumData3 },
                    };
        var retValue = query.ToList();
        return retValue;
    } // GetReport888
