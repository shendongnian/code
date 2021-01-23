    private void Page_Load(object sender, System.EventArgs e)
    {
        StringCollection adDomains = this.GetDomainList();
        foreach (string strDomain in adDomains)
        {
            Response.Write("<br>" + strDomain + "</b>");
        }
    }
    private StringCollection GetDomainList()
    {
        StringCollection domainList = new StringCollection();
        try
        {
            DirectoryEntry en = new DirectoryEntry("LDAP://");
            // Search for objectCategory type "Domain"
            DirectorySearcher srch = new DirectorySearcher("objectCategory=Domain");
            SearchResultCollection coll = srch.FindAll();
            // Enumerate over each returned domain.
            foreach (SearchResult rs in coll)
            {
                ResultPropertyCollection resultPropColl = rs.Properties;
                foreach( object domainName in resultPropColl["name"])
                {
                    domainList.Add(domainName.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Trace.Write(ex.Message);
        }
        
        return domainList;
    }							
		
