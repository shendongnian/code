        //private String _oldText;
        private String _metaData;
        public String OldText
        {
            get
            {
                //return _oldText;
                return (String)ViewState["OldText"];
            }
            set
            {
                //_oldText = value;
                ViewState["OldText"] = value;
            }
        }
        public String MetaData
        {
            get
            {
                return _metaData;
            }
            set
            {
                _metaData = value;
            }
        }
        public String NewText
        {
            get
            {
                return TextBox1.Text;
            }
            set
            {
                TextBox1.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("My ID: " + this.ID + "<br />");
            Response.Write("My Metadata: " + _metaData + "<br />");
            Response.Write("My Old Text: " + ViewState["OldText"] + "<br />");
            Response.Write("My New Text: " + TextBox1.Text + "<br />");
            ViewState["OldText"] = TextBox1.Text;
        }
