    using System.Resources;
    using System.Reflection;
    
    Assembly gerResAssembly = Assembly.LoadFrom("YourGerResourceAssembly.dll");
    var resMgr = new ResourceManager("StringResources.Strings", gerResAssembly);
    string gerString = resMgr.GetString("TheNameOfTheString");
