    private void button1_Click(object sender, EventArgs e)
    {
        var button = new Button();
        button.Size = new Size(50, 50);
        button.Click += b_Click;
        this.Controls["flowLayoutPanel"].Controls.Add(button);
    }
