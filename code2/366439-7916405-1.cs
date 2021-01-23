    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.DirectoryServices;
    namespace ADQuery
    {
    class Program
    {
        static void Main(string[] args)
        {
            GetListOfAdUsersByGroup("domain", "group");
            Console.ReadLine();
        }
        public static void GetListOfAdUsersByGroup(string domainName, string groupName)
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://DC=" + domainName + ",DC=com");
            DirectorySearcher search = new DirectorySearcher(entry);
            string query = "(&(objectCategory=person)(objectClass=user)(memberOf=*))";
            search.Filter = query;
            search.PropertiesToLoad.Add("memberOf");
            search.PropertiesToLoad.Add("name");
            System.DirectoryServices.SearchResultCollection mySearchResultColl = search.FindAll();
            Console.WriteLine("Members of the {0} Group in the {1} Domain", groupName, domainName);
            foreach (SearchResult result in mySearchResultColl)
            {
                foreach (string prop in result.Properties["memberOf"])
                {
                    if (prop.Contains(groupName))
                    {
                        Console.WriteLine("    " + result.Properties["name"][0].ToString());
                    }
                }
            }
        }
    }
