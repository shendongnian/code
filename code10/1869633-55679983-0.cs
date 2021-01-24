    Type[] typeArgs = new Type[] { aContainer };
    Type genericType = typeof(XmlContainerInitializer<>);
    Type specificType = genericListType.MakeGenericType(typeArgs);
    // This gets you a XmlContainerInitializer of the right type
    var containerInitializer = Activator.CreateInstance(specificType);
    // You can then try using it dynamically
    dynamic d = containerInitalizer;
    IBaseContainer container = (IBaseContainer)d.InitializeXmlContainer(settingsXmlFile);
    // Or, if XmlContainerInitializer supports some base interface IContainerInitializer ...
    var i = (IContainerInitializer)containerInitializer;
    IBaseContainer container = i.InitializeXmlContainer(settingsXmlFile);
