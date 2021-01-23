            private int opt; 
            public string optionInterval
            {
                get
                {
                    return opt.ToString();
                }
                set
                {
                    opt = (Convert.ToInt32)value;
                }
            }
