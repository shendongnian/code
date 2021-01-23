    using System;
    using System.DirectoryServices;
    using System.Collections.Generic;
    static class Program {
        static IEnumerable<SearchResult> GetMembers(DirectoryEntry searchRoot, string groupDn, string objectClass) {
            using (DirectorySearcher searcher = new DirectorySearcher(searchRoot)) {
                searcher.Filter = "(&(objectClass=" + objectClass + ")(memberOf=" + groupDn + "))";
                searcher.PropertiesToLoad.Clear();
                searcher.PropertiesToLoad.AddRange(new string[] { 
                    "objectGUID",
                    "sAMAccountName",
                    "distinguishedName"});
                searcher.Sort = new SortOption("sAMAccountName", SortDirection.Ascending);
                searcher.PageSize = 1000;
                searcher.SizeLimit = 0;
                foreach (SearchResult result in searcher.FindAll()) {
                    yield return result;
                }
            }
        }
        static IEnumerable<SearchResult> GetUsersRecursively(DirectoryEntry searchRoot, string groupDn) {
            List<string> searchedGroups = new List<string>();
            List<string> searchedUsers = new List<string>();
            return GetUsersRecursively(searchRoot, groupDn, searchedGroups, searchedUsers);
        }
        static IEnumerable<SearchResult> GetUsersRecursively(
            DirectoryEntry searchRoot,
            string groupDn,
            List<string> searchedGroups,
            List<string> searchedUsers) {
            foreach (var subGroup in GetMembers(searchRoot, groupDn, "group")) {
                string subGroupName = ((string)subGroup.Properties["sAMAccountName"][0]).ToUpperInvariant();
                if (searchedGroups.Contains(subGroupName)) {
                    continue;
                }
                searchedGroups.Add(subGroupName);
                string subGroupDn = ((string)subGroup.Properties["distinguishedName"][0]);
                foreach (var user in GetUsersRecursively(searchRoot, subGroupDn, searchedGroups, searchedUsers)) {
                    yield return user;
                }
            }
            foreach (var user in GetMembers(searchRoot, groupDn, "user")) {
                string userName = ((string)user.Properties["sAMAccountName"][0]).ToUpperInvariant();
                if (searchedUsers.Contains(userName)) {
                    continue;
                }
                searchedUsers.Add(userName);
                yield return user;
            }
        }
        static void Main(string[] args) {
            using (DirectoryEntry searchRoot = new DirectoryEntry("LDAP://DC=x,DC=y")) {
                foreach (var user in GetUsersRecursively(searchRoot, "CN=MainGroup,DC=x,DC=y")) {
                    Console.WriteLine((string)user.Properties["sAMAccountName"][0]);
                }
            }
        }
    }
