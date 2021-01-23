    private void ...
    {
        strSiteURL = ...
        System.Action after =
            delegate
            {
                cboUsers.Items.Clear();
                cboUsers.Items.AddRange(list.ToArray());
            };
        ThreadStart starter =
            delegate
            {
                LoadUsers(strSiteURL);
                this.Invoke(after);
            };
        Thread t = new Thread(starter);
        t.Start();
    }
