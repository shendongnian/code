    XElement cookiesRoot = appDataXml.Element("Cookies");
    foreach (XElement cookie in cookiesRoot.Elements())
    {
        ViewModels.Cookie tempCookie = new ViewModels.Cookie();
        tempCookie.Name = cookie.Element("Name").Value;
        _cookieList.Add(tempCookie);
    }
