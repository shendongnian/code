        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                divDiagram.Visible = false;
            }
        }
        void Button1_Click(object sender, EventArgs e)
        {
            divDiagram.Visible = true;
        }
