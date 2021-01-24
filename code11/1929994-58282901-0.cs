    XDocument devices = XDocument.Load(Application.StartupPath + "\\Users.xml");
    XElement conf = devices.Root.Element("Configuration");
    
    List < string > list = new List < string > ();
    IEnumerable < XElement > childElements = conf.Element("Users").Elements("User");
    var dataList = childElements.Select(el => new {
     Name = el.Element("Name").Value.ToString(),
      Surname = el.Element("Surname").Value.ToString(),
      Adress = el.Element("Adress").Value.ToString()
    });
    
    foreach(var userInfo in dataList) {
     list.Add($ "{userInfo.Name}:{userInfo.Surname}:{userInfo.Adress}");
    }
