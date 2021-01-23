    public class AccountRegistrationField
    {
        public virtual int ID { get; set; }
        public virtual int AccountID { get; set; }
        public virtual string DefaultValue { get; set; }
        public virtual int FieldID { get; set; }
        public virtual string HtmlID 
        { 
            get { return RegistrationField.HtmlID; } 
        }
        public virtual bool IsRequired { get; set; }
        public virtual string Label { get; set; }
        public virtual int Priority { get; set; }
        public virtual string FieldType 
        { 
            get { return RegistrationField.FieldType; } 
        }
        private RegistrationField RegistrationField { get; set; }
    }
