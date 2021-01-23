    string currentUserSid = WindowsIdentity.GetCurrent().User.Value;
    
                PrincipalContext ctx = new PrincipalContext(
                    ContextType.Domain,
                    "helpdesk.wat.edu");
    
                UserPrincipal up = UserPrincipal.FindByIdentity(
                    ctx, IdentityType.Sid,
                    currentUserSid);
    
                /*
                 * 
                 */
                DirectoryEntry entry = up.GetUnderlyingObject() as DirectoryEntry;
                PropertyCollection props = entry.Properties;
    
                /*
                 * 
                 */
                foreach (string propName in props.PropertyNames)
                {
                    if (entry.Properties[propName].Value != null)
                    {
                        Console.WriteLine(propName + " = " + entry.Properties[propName].Value.ToString());
                    }
                    else
                    {
                        Console.WriteLine(propName + " = NULL");
                    }
                }
    
    
                Console.ReadKey();
