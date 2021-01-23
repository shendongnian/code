        private string m_Name = new string();
        [CategoryAttribute("Tile"), DescriptionAttribute("desctiption here")]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
