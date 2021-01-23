    using System;
    using System.Xml.Serialization;
    using Microsoft.Web.Administration;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    ///...
    
    var serverManager = ServerManager.OpenRemote(@"\\myiisserver");
    var appPool = serverManager.ApplicationPools["my app pool name"];
    appPool.Recycle();
