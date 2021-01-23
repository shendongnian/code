     private string m_textToShow;
    
        public string TextToShow
        {
            get
            {
                return m_textToShow;
            }
            set
            {
                m_textToShow = value;
            }
        }
     
    
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtMyText.Text = m_textToShow;
        }
