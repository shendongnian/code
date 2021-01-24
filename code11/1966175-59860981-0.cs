    private void btn_objecten_Click(object sender, EventArgs e)
    {
        lb_objecten.Items.Clear();
        //string ou = "DC=" + lv_rootOU.SelectedItem.ToString();
        DirectoryEntry verbinding = new DirectoryEntry("LDAP://ou=Test,dc=roel,dc=gui");
        DirectorySearcher zoekOU = new DirectorySearcher(verbinding);
        zoekOU.SearchScope = SearchScope.OneLevel;
        zoekOU.PropertiesToLoad.Add("user");
        zoekOU.Filter = "(objectCategory=user)";
        foreach (SearchResult deResult in zoekOU.FindAll())
        {
            if (deResult.Properties["user"].Any())
            {
              string ouNaam = deResult.Properties["user"][0].ToString();            
              lb_objecten.Items.Add(ouNaam);
            }
        }
    }
