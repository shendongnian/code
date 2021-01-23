    // create some dynamic button
    Button b = new Button();
    // assign some event to it
    b.Click += (sender, e) => 
    {
        MessageBox.Show("the button was clicked");
    };
    // add the button to the form
    Controls.Add(b);
