    // determine the matching list of <site> nodes ...
    var selectedSites = loaded
                           .Descendants("site")
                           .Where(x => x.Element("provinceCode").Value == selectedProvince)
                           .Where(x => x.Element("nameEn").Value == selectedCity);
    // iterate over all matching <site> nodes
    foreach (var site in selectedSites)
    {
        // grab the code attribute and nameFr element from <site> node
        var siteCode = site.Attribute("code").Value;
        var nameFR = site.Element("nameFr").Value;
    }
