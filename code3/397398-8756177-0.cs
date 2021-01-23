        public string MyCharString { get; set; }
        [XmlIgnore]
        public char MyChar
        {
            get
            {
                return Convert.ToChar(MyCharString);
            }
        }
