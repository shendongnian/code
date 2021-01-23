    partial class Check
    {
        internal const decimal ScaleFactor = 0.01m;
    
        private decimal amount;
    
        [XmlAttribute("Amt")]
        public decimal XmlAmount
        {
            get { return decimal.Round(amount / ScaleFactor); }
            set { amount = value * ScaleFactor; }
        }
    
        [XmlIgnore]
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
