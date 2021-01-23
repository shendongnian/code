    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    
    namespace WebApplication2
    {
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
                {
                    // find the group in question
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "YourGroupNameHere");
    
                    // if found....
                    if (group != null)
                    {
                        // iterate over members
                        foreach (Principal p in group.GetMembers())
                        {
                            Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
                            // do whatever you need to do to those members
                        }
                    }
                }
    
            }
        }
    }
