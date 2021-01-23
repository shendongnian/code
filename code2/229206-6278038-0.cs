    using (SPSite spSite = new SPSite("http://localhost"))
    {
        using (SPWeb spWeb = spSite.OpenWeb())
        {
            SPGroupCollection spGrps = spWeb.SiteGroups;
            SPUser uGrpOwner = spWeb.CurrentUser;
            SPUser uGrpDefMember = spWeb.CurrentUser;
            string sGrpName = "GrupeName";
            spGrps.Add(sGrpName, uGrpOwner, uGrpDefMember, "Decription");
            
            SPGroup spGrp = spGrps[sGrpName];
            List<SPUser> spUsersFromAD = YouFunctionGetUserFromAD(); 
            foreach(SPUser spUser  in  spUsersFromAD){
                spGrp.AddUser(spUser);
            }
            spWeb.Update();
        }
    }
