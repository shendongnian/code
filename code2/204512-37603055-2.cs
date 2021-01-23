    static void GetUserMobile(PrincipalContext ctx, string userGuid)
    {
        try
        {
    	    UserPrincipal up = UserPrincipal.FindByIdentity(ctx, IdentityType.Guid, userGuid);
    	    DirectoryEntry up_de = (DirectoryEntry)up.GetUnderlyingObject();
    	    DirectorySearcher deSearch = new DirectorySearcher(up_de);
    	    deSearch.PropertiesToLoad.Add("mobile");
    	    SearchResultCollection results = deSearch.FindAll();
            if (results != null && results.Count > 0)
            {
    	        ResultPropertyCollection rpc = results[0].Properties;
                foreach (string rp in rpc.PropertyNames)
                {
                    if (rp == "mobile")
    	                Console.WriteLine(rpc["mobile"][0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
