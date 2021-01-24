    private void btnsetting_Click(object sender, EventArgs e)
    {
        Home main = this.ParentForm as Home;
        if (main != null)
        {
            Forms.frmEmployee employee = new Forms.frmEmployee()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            main.pncontainer.Controls.Add(employee);
            employee.Show();
        }
    }
