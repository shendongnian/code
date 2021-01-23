    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;
    
    public class ActiveDirectorySystem
    {
        private const string PROPERTY_DISPLAY_NAME = "displayName";
    
        private static DirectorySearcher Initialize()
        {
            // Exceptions are handled by the caller
    
            // Obtain the domain root entry
            using (DirectoryEntry theRootEntry = new DirectoryEntry("LDAP://RootDSE"))
            {
                object theNamingContext = null;
                string sNamingContext = null;
    
                // Verify that we retrieved it correctly and raise an error if we did not
                if (theRootEntry == null)
                {
                    throw new Exception("A directory services entry for the LDAP RootDSE could not be created.");
                }
    
                // Get the root naming context
                theNamingContext = theRootEntry.Properties["rootDomainNamingContext"].Value;
                // Verify that we retrieved it correctly and raise an error if we did not
                if ((theNamingContext == null) || (theNamingContext.ToString().Length == 0))
                {
                    throw new Exception("The root domain naming context property could not be retrieved from the LDAP directory services");
                }
                else
                {
                    sNamingContext = theNamingContext.ToString();
                }
    
                // And create a new directory entry for the root naming context
                using (DirectoryEntry theEntry = new DirectoryEntry("LDAP://" + sNamingContext))
                {
                    // Verify that we retrieved it correctly and raise an error if we did not
                    if (theEntry == null)
                    {
                        throw new Exception("A directory entry object could not be created for LDAP://" + sNamingContext);
                    }
    
                    // Now we configure what we are looking for from Active Directory
                    DirectorySearcher oSearcher = null;
    
                    // Start with a new searcher for the root domain
                    oSearcher = new DirectorySearcher(theEntry);
                    // Verify that we retrieved it correctly and raise an error if we did not
                    if (oSearcher == null)
                    {
                        throw new Exception("A directory searcher object could not be created for LDAP://" + sNamingContext);
                    }
    
                    // And the properties we want to retrieve
                    oSearcher.PropertiesToLoad.Add(PROPERTY_DISPLAY_NAME);
    
                    return oSearcher;
                }
            }
        }
    
        /// <summary>
        /// This method retrieves the set of users from active directory that meet the criteria specified in filter.
        /// </summary>
        /// <param name="sFilter"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<string> FetchContacts(string sFilter = "")
        {
            // Exceptions are handled by the caller
    
            using (DirectorySearcher oSearcher = Initialize())
            {
                if (oSearcher != null)
                {
                    List<string> cNames = new List<string>();
    
                    // Specify what we are looking for, which is the account name of the specified user without any domain information
                    oSearcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user){0})", sFilter);
    
                    // get all of the matching records
                    using (SearchResultCollection cResults = oSearcher.FindAll())
                    {
                        if (cResults != null)
                        {
                            foreach (SearchResult theCurrentResult in cResults)
                            {
                                System.DirectoryServices.ResultPropertyCollection oProperties = null;
    
                                oProperties = theCurrentResult.Properties;
                                // First, verify that at least the display name is contained in the result
                                if (oProperties.Contains(PROPERTY_DISPLAY_NAME) && oProperties[PROPERTY_DISPLAY_NAME].Count > 0)
                                {
                                    cNames.Add(oProperties[PROPERTY_DISPLAY_NAME][0].ToString());
                                }
                            }
                        }
                    }
    
                    return cNames;
                }
            }
    
            return null;
        }
    }
