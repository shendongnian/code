    private void Page_Load(object sender, System.EventArgs e)
    {
        if(!IsPostBack)
        {
            // Set the initial properties for the text boxes.
            TextBox1.Text = "TextBox1";
            TextBox2.Text = "TextBox2";
        }
    }
