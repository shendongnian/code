    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < hardrive.GetHardDriveName.Count; i++)
        {
            groupBoxHDD.Controls.Add(new Label {
                Location = new Point(10, i * 10 + 1),
                Text = "test"
            });
        }
    }
