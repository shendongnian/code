     public void btn_test_Click(object sender, EventArgs e)
        {
            string hostname = textBox1.Text;
            SiteForm frmsite = new SiteForm();
            frmsite.Load += new EventHandler(frmsite_Load);
            frmsite.ShowDialog();
        }
     public void frmsite_Load(object sender, EventArgs e)
     {
           SiteForm frmsite = sender as SiteForm;
           frmsite.hostname = this.hostname;
     }
