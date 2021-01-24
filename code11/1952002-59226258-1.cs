    private void btnsetting_Click(object sender, EventArgs e)
    {
        Forms.frmEmployee employee = new Forms.frmEmployee()
        {
            Dock = DockStyle.Fill,
            TopLevel = false,
        };
        Home main = this.Owner as Home;
        main.pncontainer.Controls.Add(employee);
        employee.Show();
    }
