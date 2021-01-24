    [XmlRoot(ElementName = "result")]
    public class Result
    {
        [XmlElement(ElementName = "fwdRate")]
        public string FwdRateStr { get; set; }
        private string lastParsedValue = null;
        private decimal fwdRate = 0;
        public decimal FwdRate 
        { 
         get 
         {
            if(FwdRateStr != lastParsedValue)
            {
                 lastParsedValue = FwdRateStr
                 fwdRate = Decimal.Parse(FwdRateStr ,System.Globalization.NumberStyles.Float)
            }
            return fwdRate
         }  
    }
    
