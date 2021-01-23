    string input = textBox1.Text;
    int n = Convert.ToInt32(input);
    for (i = 1; i <= n; i++)
    {
        Label label = new Label
        {
            Name = "label" + i,
            Location = new Point(100, 100 + i * 30),
            TabIndex = i,
            Visible = true,
            Text = "jjgggg"
        };
    
        this.Controls.Add(label);
    }
