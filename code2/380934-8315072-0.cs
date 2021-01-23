    protected void Page_Load(object sender, EventArgs e) 
        { 
            if (IsPostBack == false)
            {
                TextBox1.Text = Database.GetFirst().Text; 
            }
        }
