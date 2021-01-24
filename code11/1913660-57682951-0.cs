    public partial class ConnectionInfo 
    {
        private string accountField;
    
        public ConnectionInfo() 
        {
            this.accountField = "FOO";
        }
    
        [System.ComponentModel.DefaultValueAttribute("FOO")]
        public string account 
        {
            get 
            {
                return this.accountField;
            }
            set 
            {
                this.accountField = value;
            }
        }
    }
