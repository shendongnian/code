    string RNom = row.Cells[1].Value.ToString();
    DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://d21.tes.local", Gid, mdp);
    DirectorySearcher searcher = new DirectorySearcher(ldapConnection);
    searcher.Filter = "(sn=" + RNom + ")";
    
    searcher.PropertiesToLoad.Add("SAMAccountName");
    searcher.PropertiesToLoad.Add("sn");
    searcher.PropertiesToLoad.Add("givenName");
    searcher.PropertiesToLoad.Add("mail");
    
    using (var results = searcher.FindAll())
    {
        if (results.Count > 1)
        {
            var dataGridView2 = ??; //You need to set this to something different each time, otherwise you will just overwrite it
            dataGridView2.RowCount = results.Count;
            var rowId = 0;
            foreach (SearchResult result in results)
            {
                var r = dataGridView2.Rows[rowId];
                r.Cells[0].Value = result.Properties["SAMAccountName"][0];
                r.Cells[1].Value = result.Properties["sn"][0];
                r.Cells[2].Value = result.Properties["givenName"][0];
                r.Cells[3].Value = result.Properties["mail"][0];
                
                rowId++;
            }
        }
        else if (results.Count == 1)
        {
            var result = results[0];
            row.Cells[0].Value = result.Properties["SAMAccountName"][0];
            row.Cells[1].Value = result.Properties["sn"][0];
            row.Cells[2].Value = result.Properties["givenName"][0];
            row.Cells[3].Value = result.Properties["mail"][0];
        }
        else
        {
            //no results
        }
    }
