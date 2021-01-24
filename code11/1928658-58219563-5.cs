        public string Character
        {
            get { return character; }
            set
            {
                if (value.Equals("Han Solo", StringComparison.OrdinalIgnoreCase) 
                    || value.Equals("Leia", StringComparison.OrdinalIgnoreCase))
                {
                    character = value.ToUpper();
                }
                else
                {
                    character = "INCORRECT CHARACTER!!!!";
                }
            }
        }
