    // Override auto-implemented property with ordinary property
       // to provide specialized accessor behavior.
        public override string Email
        {
            get
            {
                return email;//declare this private string also in model
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    email= "Unknown";
                }
            }
        } 
