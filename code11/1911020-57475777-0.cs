    public class RootObject
    {
        public FinancialPositions[] financialPositions{ get; set; }
    
        public object this[string name]
        {
              get { return financialPositions.FirstOrDefault(f => f.fieldName  == name); }
              set { }
        }
    }
