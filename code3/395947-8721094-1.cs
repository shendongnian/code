     public double CustBalance
        {
            get
            {
                return custBalance;
            }
            set
            {
                // CustBalance = value; <-- It will assign value to property not a field
                //                          will cause StackOverflow
                custBalance=value;                          
            }
        }
