    foreach (XElement cookie in appDataXml.Elements())
    {
        ViewModels.Cookie tempCookie = new ViewModels.Cookie();
        tempCookie.Name = cookie.Element("Name").Value;
        _cookieList.Add(tempCookie);
    }
