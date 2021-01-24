    private void button1_Click(object sender, EventArgs e)
    {
        // Check that nothing has been added yet.
        if (panel1.Controls.Count == 0)
        {
            UserControl1 uc1 = new UserControl1();
            uc1.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc1);
        }
    }
