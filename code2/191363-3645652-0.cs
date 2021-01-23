    for (int i = 0; i < 10; i++)
    {
        var btn = new Button();
        btn.Text = "Button " + i;
        btn.Location = new Point(10, 30 * (i + 1) - 16);
        btn.Click += (sender, args) =>
        {
            // sender is the instance of the button that was clicked
            MessageBox.Show(((Button)sender).Text + " was clicked");
        };
        Controls.Add(btn);
    }
