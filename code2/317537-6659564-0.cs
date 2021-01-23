    private void leadsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        formWeblead formWeblead = null;
        if ((formWeblead = IsFormAlreadyOpen(typeof(frmWebLeads)) == null)
        {
            formWeblead = new frmWebLeads();
            formWeblead.MdiParent = this;
            formWeblead.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            formWeblead.Show();
        }
    }
    
    public static Form IsFormAlreadyOpen(Type FormType)
    {
       foreach (Form OpenForm in Application.OpenForms)
       {
          if (OpenForm.GetType() == FormType)
             return OpenForm;
       }
       return null;
    }
