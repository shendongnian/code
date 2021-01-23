    protected void Page_Load(object sender, EventArgs e)
    {
       TextBox1.Text = Session["fname"].ToString();
       TextBox2.Text = Session["lname"].ToString();
    }
