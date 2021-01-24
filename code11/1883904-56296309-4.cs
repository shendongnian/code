    // A backup label for our scrolling label5
    private Label label5_backup;
    private void Form1_Load(object sender, EventArgs e)
    {
        label5.Text = "This is a scrolling label!";
        // Set label5_backup to look like label5
        label5_backup = new Label
        {
            Size = label5.Size,
            Text = label5.Text,
            Top = label5.Top,
            Visible = false
        };
        Controls.Add(label5_backup);
        timer2.Interval = 1;
        timer2.Start();
    }
