    protected override void OnInit(EventArgs e)
    {
        // test data
        var documents = new Dictionary<string, string>();
        documents.Add("69110", "Diploma");
        documents.Add("76404", "Licensure");
        foreach (KeyValuePair<string, string> item in documents)
        {
            Button button = new Button();
            button.Text = string.Format("Button: {0}", item.Key);
            button.CommandArgument = item.Key;
            button.Click += ButtonClicked;
            ButtonContainer.Controls.Add(button);
        }
        base.OnInit(e);
    }
    protected void ButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button) sender;
        string id = button.CommandArgument;
        DisplayDocument(id);
    }
    private void DisplayDocument(string id)
    {
        //Do something
    }
