    XNamespace xns = "http://schemas.microsoft.com/search/local/ws/rest/v1";
    _xml = XElement.Parse(e.Result);
    results.Items.Clear();
    foreach (XElement value in _xml
        .Descendants(xns + "ResourceSets").Descendants(xns + "ResourceSet")
        .Descendants(xns + "Resources").Descendants(xns + "Location"))
    {
        Results _item = new Results();
        _item.Place = value.Element(xns + "Name").Value;
        _item.Lat = value.Element(xns + "Point").Element(xns + "Latitude").Value;
        _item.Long = value.Element(xns + "Point").Element(xns + "Longitude").Value;
        results.Items.Add(_item);
    }
