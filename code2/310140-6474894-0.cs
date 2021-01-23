    using System;
    using System.DirectoryServices;
    namespace ADAM_Examples
    {
    class EnumMembers
    {
        /// <summary>
        /// Enumerate AD LDS groups and group members.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DirectoryEntry objADAM;                   // Binding object.
            DirectoryEntry objGroupEntry;             // Group Results.
            DirectorySearcher objSearchADAM;          // Search object.
            SearchResultCollection objSearchResults;  // Results collection.
            string strPath;                           // Binding path.
            // Construct the binding string.
            strPath = "LDAP://localhost:389/OU=TestOU,O=Fabrikam,C=US";
            Console.WriteLine("Bind to: {0}", strPath);
            Console.WriteLine("Enum:    Groups and members.");
            // Get the AD LDS object.
            try
            {
                objADAM = new DirectoryEntry(strPath);
                objADAM.RefreshCache();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:   Bind failed.");
                Console.WriteLine("         {0}", e.Message);
                return;
            }
            // Get search object, specify filter and scope,
            // perform search.
            try
            {
                objSearchADAM = new DirectorySearcher(objADAM);
                objSearchADAM.Filter = "(&(objectClass=group))";
                objSearchADAM.SearchScope = SearchScope.Subtree;
                objSearchResults = objSearchADAM.FindAll();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:   Search failed.");
                Console.WriteLine("         {0}", e.Message);
                return;
            }
            // Enumerate groups and members.
            try
            {
                if (objSearchResults.Count != 0)
                {
                    foreach(SearchResult objResult in objSearchResults)
                    {
                        objGroupEntry = objResult.GetDirectoryEntry();
                        Console.WriteLine("Group    {0}",
                            objGroupEntry.Name);
                        foreach(object objMember
                            in objGroupEntry.Properties["member"])
                        {
                            Console.WriteLine(" Member: {0}",
                                objMember.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Results: No groups found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:   Enumerate failed.");
                Console.WriteLine("         {0}", e.Message);
                return;
            }
            Console.WriteLine("Success: Enumeration complete.");
            return;
        }
    }
}
