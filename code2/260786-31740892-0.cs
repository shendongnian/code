    private DateTime? dob;
            public DateTime? DOB
            {
                get
                {
                    if (dob != null)
                    {
                        return dob.Value.Date;
                    }
                    else
                    {
                        return null;
                    }
    
                }
                set { dob = value; }
            }
