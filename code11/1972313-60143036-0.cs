    private void btAdd_Click(object sender, EventArgs e)
    {
        SubForm sub = new SubForm();
        this.IsMdiContainer = true;
        sub.TopLevel = false;
        panel1.Controls.Add(sub);
        sub.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        sub.Dock = DockStyle.Fill;
        sub.Show();
    }
