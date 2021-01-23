		static List<SearchResult> ad_find_all_members(string a_sSearchRoot, string a_sGroupDN, string[] a_asPropsToLoad)
		{
		    using (DirectoryEntry de = new DirectoryEntry(a_sSearchRoot))
		        return ad_find_all_members(de, a_sGroupDN, a_asPropsToLoad);
		}
		
		static List<SearchResult> ad_find_all_members(DirectoryEntry a_SearchRoot, string a_sGroupDN, string[] a_asPropsToLoad)
		{
		    string sDN = "distinguishedName";
		    string sOC = "objectClass";
		    string sOC_GROUP = "group";
		    string[] asPropsToLoad = a_asPropsToLoad;
		    Array.Sort<string>(asPropsToLoad);
		    if (Array.BinarySearch<string>(asPropsToLoad, sDN) < 0)
		    {
		        Array.Resize<string>(ref asPropsToLoad, asPropsToLoad.Length+1);
		        asPropsToLoad[asPropsToLoad.Length-1] = sDN;
		    }
		    if (Array.BinarySearch<string>(asPropsToLoad, sOC) < 0)
		    {
		        Array.Resize<string>(ref asPropsToLoad, asPropsToLoad.Length+1);
		        asPropsToLoad[asPropsToLoad.Length-1] = sOC;
		    }
		
		    List<SearchResult> lsr = new List<SearchResult>();
		
		    using (DirectorySearcher ds = new DirectorySearcher(a_SearchRoot))
		    {
		        ds.Filter = "(&(|(objectClass=group)(objectClass=user))(memberOf=" + a_sGroupDN + "))";
		        ds.PropertiesToLoad.Clear();
		        ds.PropertiesToLoad.AddRange(asPropsToLoad);
		        ds.PageSize = 1000;
		        ds.SizeLimit = 0;
		        foreach (SearchResult sr in ds.FindAll())
		            lsr.Add(sr);
		    }
		    
		    for(int i=0;i<lsr.Count;i++)
		        if (lsr[i].Properties.Contains(sOC) && lsr[i].Properties[sOC].Contains(sOC_GROUP))
		            lsr.AddRange(ad_find_all_members(a_SearchRoot, (string)lsr[i].Properties[sDN][0], asPropsToLoad));
		
		    return lsr;
		}
		
		static void Main(string[] args)
		{
        foreach (var sr in ad_find_all_members("LDAP://DC=your-domain,DC=com", "CN=your-group-name,OU=your-group-ou,DC=your-domain,DC=com", new string[] { "sAMAccountName" }))
            Console.WriteLine((string)sr.Properties["distinguishedName"][0] + " : " + (string)sr.Properties["sAMAccountName"][0]);
		}
