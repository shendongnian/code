	//class member for the only formWeblead
	frmWebLeads formWebLead = null;
	private void leadsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (formWebLead == null)
		{
			formWeblead = new frmWebLeads();
			formWeblead.MdiParent = this;
		}
		formWeblead.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		formWeblead.Show();
	}
