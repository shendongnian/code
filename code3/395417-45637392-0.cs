    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace AD_LDAP
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Group Email: ");
                string groupEmail = Console.ReadLine();
                List<ADUser> members = getGroupMembers.MembersInGroup(groupEmail);
                if (members != null && members.Count > 0)
                {
                    Console.WriteLine(Environment.NewLine + "Total Users: " + members.Count + Environment.NewLine);
                    Console.WriteLine("*********************** Users in group ************************" + Environment.NewLine);
                    Console.WriteLine("Users-Id" + "\t\t" + "Email Address" + Environment.NewLine);
                    foreach (ADUser item in members)
                    {
                        Console.WriteLine(item.UserId + "\t\t\t" + item.EmailAddress);
                    }
                }
                else
                {
                    if (members == null)
                        Console.WriteLine("Invalid group email!");
                    else
                        Console.WriteLine("Group email has no members");
                }
                Console.ReadLine();
            }
        }
    
        class ADUser
        {
            public string UserId { get; set; }
            public string EmailAddress { get; set; }
        }
    
        class getGroupMembers
        {
            /// <summary>
            /// searchedGroups will contain all groups already searched, in order to
            /// prevent endless loops when there are circular structured in the groups.
            /// </summary>
            static Hashtable searchedGroups = null;
    
            /// <summary>
            /// "MembersInGroup" will return all users in the group passed in as a parameter
            /// The function will recursively search all nested groups.
            /// Remark: if there are multiple groups with the same name, this function will just use the first one it finds.
            /// </summary>
            /// <param name="strGroupEmail">Email of the group, which the users should be retrieved from</param>
            /// <returns>ArrayList containing the emails of all users in this group and any nested groups</returns>
            static public List<ADUser> MembersInGroup(string strGroupEmail)
            {
                List<ADUser> groupMembers = null;
                searchedGroups = new Hashtable();
    
                // find group
                DirectorySearcher searchGroup = new DirectorySearcher("LDAP://DC=,DC=com");
                searchGroup.Filter = ("mail=" + strGroupEmail);
                SearchResult result = searchGroup.FindOne();
                if (result != null && Convert.ToString(result.Properties["objectclass"][1]) == "group")
                {
                    DirectorySearcher search = new DirectorySearcher("LDAP://DC=Your Domain Network,DC=com");
                    search.Filter = String.Format("(&(objectCategory=group)(cn={0}))", Convert.ToString(result.Properties["samaccountname"][0]));
                    search.PropertiesToLoad.Add("distinguishedName");
                    SearchResult sru = null;
                    try
                    {
                        sru = search.FindOne();
                        DirectoryEntry group = sru.GetDirectoryEntry();
                        groupMembers = getUsersInGroup(group.Properties["distinguishedName"].Value.ToString());
                    }
                    catch { }
                }
                return groupMembers;
            }
    
            /// <summary>
            /// getUsersInGroup will return all users in the group passed in as a parameter
            /// The function will recursively search all nested groups.
            /// </summary>
            /// <param name="strGroupDN">"distinguishedName" of the group, which the users should be retrieved from</param>
            /// <returns>ArrayList containing the email of all users in this group and any nested groups</returns>
            private static List<ADUser> getUsersInGroup(string strGroupDN)
            {
                List<ADUser> groupMembers = new List<ADUser>();
                searchedGroups.Add(strGroupDN, strGroupDN);
    
                // find all users in this group
                DirectorySearcher ds = new DirectorySearcher("LDAP://DC=Your Domain Network,DC=com");
                ds.Filter = String.Format("(&(memberOf={0})(objectClass=person))", strGroupDN);
                ds.PropertiesToLoad.Add("distinguishedName");
                ds.PropertiesToLoad.Add("samaccountname");
                ds.PropertiesToLoad.Add("mail");
                foreach (SearchResult sr in ds.FindAll())
                {
                    if (sr.Properties["mail"].Count > 0)
                        groupMembers.Add(new ADUser { UserId = sr.Properties["samaccountname"][0].ToString(), EmailAddress = sr.Properties["mail"][0].ToString() });
                }
    
                // get nested groups
                ArrayList al = getNestedGroups(strGroupDN);
                foreach (object g in al)
                {
                    if (!searchedGroups.ContainsKey(g)) // only if we haven't searched this group before - avoid endless loops
                    {
                        // get members in nested group
                        List<ADUser> ml = getUsersInGroup(g as string);
                        // add them to result list
                        foreach (ADUser s in ml)
                        {
                            groupMembers.Add(s);
                        }
                    }
                }
                return groupMembers;
            }
    
            /// <summary>
            /// getNestedGroups will return an array with the "distinguishedName" of all groups contained
            /// in the group that was passed in as a parameter
            /// </summary>
            /// <param name="strGroupDN">"distinguishedName" of the group, which the nested groups should be retrieved from</param>
            /// <returns>ArrayList containing the "distinguishedName" of each group contained in the group apssed in asa parameter</returns>
            private static ArrayList getNestedGroups(string strGroupDN)
            {
                ArrayList groupMembers = new ArrayList();
                // find all nested groups in this group
                DirectorySearcher ds = new DirectorySearcher("LDAP://DC=Your Domain Network,DC=com");
                ds.Filter = String.Format("(&(memberOf={0})(objectClass=group))", strGroupDN);
                ds.PropertiesToLoad.Add("distinguishedName");
                foreach (SearchResult sr in ds.FindAll())
                {
                    groupMembers.Add(sr.Properties["distinguishedName"][0].ToString());
                }
                return groupMembers;
            }
        }
    }
