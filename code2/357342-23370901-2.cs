    string dn = "CN=TestGroup,OU=Groups,OU=UT-SLC,OU=US,DC=Company,DC=com";
    Assembly dirsvc = Assembly.Load("System.DirectoryServices");
    Type asmType = dirsvc.GetType("System.DirectoryServices.ActiveDirectory.Utils");
    MethodInfo mi = asmType.GetMethod("GetDNComponents", BindingFlags.NonPublic | BindingFlags.Static);
    string[] parameters = { dn };
    var test = mi.Invoke(null, parameters);
    //test.Dump("test1");//shows details when using Linqpad 
    
    //Convert Distinguished Name (DN) to Relative Distinguished Names (RDN) 
    MethodInfo mi2 = asmType.GetMethod("GetRdnFromDN", BindingFlags.NonPublic | BindingFlags.Static);
    var test2 = mi2.Invoke(null, parameters);
    //test2.Dump("test2");//shows details when using Linqpad 
