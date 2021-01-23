    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < hardrive.GetHardDriveName.Count; i++)
        {
            // Assuming you're using C# 3 or higher
            Label label = new Label {
                Location = new Point(10, i * 10 + 1),
                Text = "test"
            };
            groupBoxHDD.Controls.Add(label);
        }
    }
