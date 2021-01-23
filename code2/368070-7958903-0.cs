    protected void Page_Load(object sender, EventArgs e)
    {
        string buttonId = "Button1";
        UpdatePanel updatePanel = new UpdatePanel();
        updatePanel.ID = "UpdatePanel1";
            
        Button button = new Button();
        button.ID = "Button1";
        button.Text = "Post back";
        button.Click += new EventHandler(button_Click);
        updatePanel.Triggers.Add(new PostBackTrigger() { ControlID = buttonId});
        updatePanel.ContentTemplateContainer.Controls.Add(button);
        Panel1.Controls.Add(updatePanel);
    }
    void button_Click(object sender, EventArgs e)
    {
        Label1.Text = string.Format("Current date/time: {0}", DateTime.Now.ToString());
    }
