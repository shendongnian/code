    private void btnSelectSite_Click(object sender, EventArgs e)
    {
        strSiteURL = txtSiteURL.Text;
        tmrProgressTimer.Interval = 1000;
        tmrProgressTimer.Enabled = true;
        ThreadStart starter = () => 
        {
            LoadUsers(strSiteURL);
            
            cboUsers.Invoke(() => 
            {
                cboUsers.Items.Clear();
                cboUsers.Items.AddRange(list.ToArray());
                tmrProgressTimer.Enabled = false;
            });  
        };
        Thread t = new Thread(starter);
        t.Start();
    }
