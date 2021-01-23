    protected void Page_Load(object sender, EventArgs e)
    {
        Button button = new Button();
        button.Text = "Click me";
        button.Click += new EventHandler(button_Click);
        updatePanel.ContentTemplateContainer.Controls.Add(button);
    }
    protected void button_Click(Object sender, EventArgs e)
    {
        litMessage.Text = ((Button)sender).Text + " clicked.";
    }
