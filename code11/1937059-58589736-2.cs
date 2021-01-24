    class DerivedCpo : AbstractPo
    {
        private string poNumber;
        private Dictionary<string, object> invalidFieldsBackingField;
        public override Dictionary<string, object> InvalidFields
        {
            get
            {
                return invalidFieldsBackingField;
            }
            set { this.invalidFieldsBackingField = value; }
        }
    
        public DerivedCpo()
        {
            this.InvalidFields = new Dictionary<string, object>();
        }
        public override string PoNumber
        {
            get { return poNumber;}
            set
            {
                if(!ValidatePONumber((value)))
                    InvalidFields.Add("CPO Number", value);
                poNumber = value;
            }
        }
    
        
    
        private bool ValidatePONumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
    
            if (value.Length > 5)
                return false;
    
            return true;
        }
    }
