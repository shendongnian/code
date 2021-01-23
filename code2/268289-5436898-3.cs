    protected override void CreateChildControls()
    {
        base.CreateChildControls();
        Button button = new Button();
        button.Text = "Click me";
        button.Click += new EventHandler(button_Click);
        updatePanel.ContentTemplateContainer.Controls.Add(button);
    }
    protected void button_Click(Object sender, EventArgs e)
    {
        litMessage.Text = ((Button)sender).Text + " clicked.";
    }
