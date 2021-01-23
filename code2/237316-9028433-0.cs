    var dbpath = @"C:\path\to\passwords.kdbx";
    var masterpw = "Your$uper$tr0ngMst3rP@ssw0rd";
    
    var ioConnInfo = new IOConnectionInfo {	Path = dbpath };
    var compKey = new CompositeKey();
    compKey.AddUserKey(new KcpPassword(masterpw));
    
    var db = new KeePassLib.PwDatabase();
    db.Open(ioConnInfo, compKey, null);
    
    var kpdata = from entry in db.RootGroup.GetEntries(true)
    				select new
    				{
    					Group = entry.ParentGroup.Name,
    					Title = entry.Strings.ReadSafe("Title"),
    					Username = entry.Strings.ReadSafe("UserName"),
    					Password = entry.Strings.ReadSafe("Password"),
    					URL = entry.Strings.ReadSafe("URL"),
    					Notes = entry.Strings.ReadSafe("Notes")
    					
    				};																					
    
    kpdata.Dump(); // this is how Linqpad outputs stuff
    db.Close();
