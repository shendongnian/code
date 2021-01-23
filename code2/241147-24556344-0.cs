    using System.Resources;
    using System.Reflection;
    
    Assembly gerResAssembly = Assembly.LoadFrom("YourGerResourceAssembly.dll");
    var resMgr = new ResourceManager("StringResources.Strings", gerResAssembly);
    // for example german:
    string strDE = resMgr.GetString("TheNameOfTheString",  new CultureInfo("de"));
    // for example spanish
    string strES = resMgr.GetString("TheNameOfTheString",  new CultureInfo("es"));
