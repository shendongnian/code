    protected void Page_Load(object sender, EventArgs e)
    {
        if (TextBox.Text.Trim().Length > 0)
        {
          TextBox.Text = String.Empty;
        }
    }
