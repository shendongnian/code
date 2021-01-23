        private Ability str;
        public Ability Str 
        {
            get
            {
                return this.str;
            }
            set
            {
                if (value.Name == "")
                {
                    this.str.Score = value.Score;
                }
                else
                {
                    this.str = value;
                }
            }
        }
