    using (SPSite site = new SPSite(SPContext.Current.Web.Url))
    {
        using (SPWeb web = site.OpenWeb())
        {
            SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["Documents"];
            SPQuery qry = new SPQuery();
            qry.Query = "<Where><Eq><FieldRef Name='Title'><Value Type='Text'>"+title+"</Value></Eq></Where>";
            SPListItemCollection docColl = new SPListItemCollection(qry);
            List<string> perms = new List<string>();
            if (docColl.Count > 0)
            {
                SPListItem fldrItem = docColl[0];
                if (fldrItem.RoleAssignments.Count > 0) {
                    
                    SPRoleAssignmentCollection assignColl = fldrItem.RoleAssignments;
                    foreach (SPRoleAssignment assignment in assignColl)
                    {
                        perms.Add(assignment.Member.LoginName);
                        Console.WriteLine("Perms: " + assignment.Member.LoginName);
                    }
                }
            }
        }
    }
