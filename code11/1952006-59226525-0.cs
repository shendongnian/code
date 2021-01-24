	private void btnsetting_Click(object sender, EventArgs e)
	{
		frmEmployee employee = new frmEmployee()
		{
			Dock = DockStyle.Fill,
			TopLevel = false,
		};
		Form frm = this.Parent.FindForm();
		Control match = frm.Controls.Find("pncontainer", true).FirstOrDefault();
		if (match != null && match is Panel)
		{
			Panel p = (Panel)match;
			p.Controls.Clear();
			p.Controls.Add(employee);
			employee.Show();
		}
	}
