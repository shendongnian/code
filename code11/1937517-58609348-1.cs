    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var result = new List<string>();
        var lockedUsers = new List<UserPrincipal>();
        using (var context = new PrincipalContext(ContextType.Domain, "domain", smtu, smtp))
        {
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "Domain Users");
            foreach (var userPrincipal in grp.GetMembers(false))
            {
                var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userPrincipal.SamAccountName);
                if (user != null)
                {
                    if (user.IsAccountLockedOut())
                    {
                        result.Add(@"domain\ " + user);
                    }
                }
            }
        }
        e.Result = result;
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            // Error handling.
        }
        if (e.Cancelled)
        {
           // If you support cancellation...
        }
        listBox1.Items.Clear();
        listBox1.Items.AddRange((e.Result as List<string>).ToArray());
    }
