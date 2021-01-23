    var site = loaded
        .Descendants("site")
        .FirstOrDefault(x => (string)x.Element("provinceCode") == selectedProvince &&
                        x => (string)x.Element("nameEn") == selectedCity);    
    if (site == null)
    {
        return
    }
    var siteCode = (string)site.Attribute("code");
    var nameFr = (string)site.Element("nameFr");
