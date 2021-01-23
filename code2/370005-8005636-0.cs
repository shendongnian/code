    // This is a method body
    {
        Button btnClear = new Button
        {
            Text = "Clear",
            Name = "btnClear",
            Location = new Point(416, 17)
        };
        p.Controls.Add(btnClear);
        btnClear.Click += new EventHandler(btnClear_Click);
    }
    void btnClear_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
