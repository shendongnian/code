    // what will be needed:    
    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;
    var userSignOn = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name;
    List<string> activedirectoryGroupList = new List<string>();
    activedirectoryGroupList = GetGroupsFromSignOn(userSignOn);
