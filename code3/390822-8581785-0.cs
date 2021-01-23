    using System;
    using System.Text;
    using System.Collections;
    using System.DirectoryServices;
    using System.Diagnostics;
    using System.Data.Common;
    
    namespace Vertex_VVIS.SourceCode
    {
        public class LdapAuthentication
        {
            private String _path;
            private String _filterAttribute;
    
            public LdapAuthentication(String path)
            {
                _path = path;
            }
     public bool IsAuthenticated(String domain, String username, String pwd)
            {
                String domainAndUsername = domain + @"\" + username;
                DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
    
                try
                {	//Bind to the native AdsObject to force authentication.			
                  //  Object obj = entry.NativeObject;
    
                    DirectorySearcher search = new DirectorySearcher(entry);
    
                    search.Filter = "(SAMAccountName=" + username + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();
    
                    if (null == result)
                    {
                        return false;
                    }
    
                    //Update the new path to the user in the directory.
                    _path = result.Path;
                    _filterAttribute = (String)result.Properties["cn"][0];
                }
                catch (Exception ex)
                {
                    throw new Exception("Error authenticating user. " + ex.Message);
                }
    
                return true;
            }
    
            public String GetName(string username)
            {
                
                String thename = null;
    
                try
                {
                    DirectoryEntry de = new DirectoryEntry(_path);
                    DirectorySearcher ds = new DirectorySearcher(de);
                    ds.Filter = String.Format("(SAMAccountName={0})", username);
                    ds.PropertiesToLoad.Add("displayName");
                    SearchResult result = ds.FindOne();
                    if (result.Properties["displayName"].Count > 0)
                    {
                        thename = result.Properties["displayName"][0].ToString();
                    }
                    else
                    {
                        thename = "NA";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Getting Name. " + ex.Message);
                }
    
                return thename.ToString();
            }
    
            public String GetEmailAddress(string username)
            {
                String theaddress = null;
                try
                {
                    DirectoryEntry de = new DirectoryEntry(_path);
                    DirectorySearcher ds = new DirectorySearcher(de);
                    ds.Filter = String.Format("(SAMAccountName={0})", username);
                    ds.PropertiesToLoad.Add("mail");
                    SearchResult result = ds.FindOne();
                    theaddress = result.Properties["mail"][0].ToString();
                    de.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Getting Email Address. " + ex.Message);
                }
    
                return theaddress.ToString();
            }
            public String GetTitle(string username)
            {
                String thetitle = null;
                try
                {
                    DirectoryEntry de = new DirectoryEntry(_path);
                    DirectorySearcher ds = new DirectorySearcher(de);
                    ds.Filter = String.Format("(SAMAccountName={0})", username);
                    ds.PropertiesToLoad.Add("title");
                    SearchResult result = ds.FindOne();
                    result.GetDirectoryEntry();
                    if (result.Properties["title"].Count > 0)
                    {
                        thetitle = result.Properties["title"][0].ToString();
                    }
                    else
                    {
                        thetitle = "NA";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Getting the Title. " + ex.Message);
                }
    
                return thetitle.ToString();
            }
    
            public String GetPhone(string username)
            {
                String thephone = null;
                try
                {
                    DirectoryEntry de = new DirectoryEntry(_path);
                    DirectorySearcher ds = new DirectorySearcher(de);
                    ds.Filter = String.Format("(SAMAccountName={0})", username);
                    ds.PropertiesToLoad.Add("mobile");
                    SearchResult result = ds.FindOne();
                    result.GetDirectoryEntry();
                    if (result.Properties["mobile"].Count > 0)
                    {
                        thephone = result.Properties["mobile"][0].ToString();
                    }
                    else
                    {
                        thephone = "NA";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Getting Phone Number. " + ex.Message);
                }
    
                return thephone.ToString();
            }
    
            public String GetGroups()
            {
                DirectorySearcher search = new DirectorySearcher(_path);
               search.Filter = "(cn=" + _filterAttribute + ")";
               search.PropertiesToLoad.Add("memberOf");
                StringBuilder groupNames = new StringBuilder();
    
                try
                {
                    SearchResult result = search.FindOne();
    
                    int propertyCount = result.Properties["memberOf"].Count;
    
                    String dn;
                    int equalsIndex, commaIndex;
    
                    for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                    {
                        dn = (String)result.Properties["memberOf"][propertyCounter];
    
                        equalsIndex = dn.IndexOf("=", 1);
                        commaIndex = dn.IndexOf(",", 1);
                        if (-1 == equalsIndex)
                        {
                            return null;
                        }
    
                        groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                        groupNames.Append("|");
    
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error obtaining group names. " + ex.Message);
                }
                return groupNames.ToString();
            }
    
            public bool IsUserGroupMember(string strUserName, string strGroupString)
            {
                bool bMemberOf = false;
                ResultPropertyValueCollection rpvcResult = null; 
                try
                {
                    DirectoryEntry de = new DirectoryEntry(_path);
                    DirectorySearcher ds = new DirectorySearcher(de);
                    ds.Filter = String.Format("(SAMAccountName={0})", strUserName);
                    ds.PropertiesToLoad.Add("memberOf");
                    SearchResult result = ds.FindOne();
                    string propertyName = "memberOf";  
                    rpvcResult = result.Properties[propertyName];  
    
                    foreach (Object propertyValue in rpvcResult)  
                     {
                         if (propertyValue.ToString().ToUpper() == strGroupString.ToUpper())
                         {  
                             bMemberOf = true;
                             break;
                         }  
                     }  
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Getting member of. " + ex.Message);
                }
    
                return bMemberOf;
       
            }
        }
    }
           
