    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Text;  
    using System.DirectoryServices;  
     
    namespace GetGroupsForADUser  
    {  
        class Program  
        {  
            static void Main(string[] args)  
            {  
                String username = "Gabriel";  
     
                List<string> userNestedMembership = new List<string>();  
     
                DirectoryEntry domainConnection = new DirectoryEntry();  
                domainConnection.Path = "LDAP://DC=mydomain,DC=local";  
                domainConnection.AuthenticationType = AuthenticationTypes.Secure;  
     
     
                DirectorySearcher samSearcher = new DirectorySearcher();  
     
                samSearcher.SearchRoot = domainConnection;  
                samSearcher.Filter = "(samAccountName=" + username + ")";  
                samSearcher.PropertiesToLoad.Add("displayName");  
     
                SearchResult samResult = samSearcher.FindOne();  
     
                if (samResult != null)  
                {  
                    DirectoryEntry theUser = samResult.GetDirectoryEntry();  
                    theUser.RefreshCache(new string[] { "tokenGroups" });  
     
                    foreach (byte[] resultBytes in theUser.Properties["tokenGroups"])  
                    {  
                        System.Security.Principal.SecurityIdentifier mySID = new System.Security.Principal.SecurityIdentifier(resultBytes, 0);  
     
                        DirectorySearcher sidSearcher = new DirectorySearcher();  
     
                        sidSearcher.SearchRoot = domainConnection;  
                        sidSearcher.Filter = "(objectSid=" + mySID.Value + ")";  
                        sidSearcher.PropertiesToLoad.Add("distinguishedName");  
     
                        SearchResult sidResult = sidSearcher.FindOne();  
     
                        if (sidResult != null)  
                        {  
                            userNestedMembership.Add((string)sidResult.Properties["distinguishedName"][0]);  
                        }  
                    }  
     
                    foreach (string myEntry in userNestedMembership)  
                    {  
                        Console.WriteLine(myEntry);  
                    }  
     
                }  
                else 
                {  
                    Console.WriteLine("The user doesn't exist");  
                }  
     
                Console.ReadKey();  
     
            }  
        }  
    }  
