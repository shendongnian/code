        public string MyVar { get; set; }
        public string MyVarFirstChar
        {
            get { return MyVar.Substring(0, 2); }
        }
