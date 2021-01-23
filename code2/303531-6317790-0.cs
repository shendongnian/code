    var xmlUri = new Uri("/WindowsPhoneDataBoundApplication1;component/Cookies.xml",
                         UriKind.Relative);
    var xmlStream = Application.GetResourceStream(xmlUri);
    var doc = XDocument.Load(xmlStream);
    var newCookies = doc
        .Descendants("Cookie")
        .Select(e =>
            new ViewModels.Cookie
            {
                Name = e.Element("Name").Value,
                // initialize any other values you need here            
                Description = e.Element("Description").Value,
                Ingredients = e
                    .Element("Ingredients")
                    .Elements("Ingredient")
                    .Select(i =>
                        new Ingredient
                        {
                            Name = i.Element("Name").Value,
                            Amount = i.Element("Amount").Value,
                        }),
                Duration = (double)e.Element("Duration"),
                // etc.
            });
    _cookieList.AddRange(newCookies); // add the cookies to our existing list
