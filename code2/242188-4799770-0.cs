    Button queryButton = new Button();
    queryButton.UseSubmitBehavior = false;
    queryButton.ID = "querybutton";
    queryButton.Text = "Query";
    queryButton.Click += new EventHandler(queryButton_Click);
    Controls.Add(queryButton);
