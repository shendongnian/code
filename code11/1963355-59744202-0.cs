    private void Form1_Load(object sender, EventArgs e)
    {
        panel1.Controls.Add(new UserControl1 { Visible = false });
        panel1.Controls.Add(new UserControl2 { Visible = false });
        panel1.Controls.Add(new UserControl3 { Visible = false });
    }
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (Control control in panel1.Controls)
        {
            if (control is UserControl1)
            {
                control.Visible = true;
                control.BringToFront();
            }
            else
            {
                control.Visible = false;
            }
        }
    }
