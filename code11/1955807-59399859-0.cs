        [Serializable]
    public class ChartDataSet {
        public string label {get;set;}
        public string backgroundColor {get;set;}
        public List<double> data {get;set;}
        public ChartDataSet(string lbl, string bgcolor, List<double> datavalue)
        {
            label = lbl;
            backgroundColor = bgcolor;
            data = datavalue;
        }
    }
