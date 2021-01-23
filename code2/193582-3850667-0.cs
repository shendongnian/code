        private String name;
        [System.Diagnostics.DebuggerHidden()]
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Please enter a name.");
                }
            }
        }
