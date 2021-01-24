    private void btnsetting_Click(object sender, EventArgs e)
    {
        Home main = Application.OpenForms.OfType<Home>().FirstOrDefault();
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
