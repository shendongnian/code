    Button b = new Button();
    b.Text = "Go back!";
    b.ID = "btn_Back";
    b.Click += new EventHandler(B_Click);
    Controls.Add(b);
    // ...
    private void B_Click(object sender, EventArgs e)
    {
        // ...
    }
