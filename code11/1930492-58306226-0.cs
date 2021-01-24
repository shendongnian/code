    IEnumerable<string> skundename = from SKF in doc.Descendants("Property").
                                     Where(v => v.Attribute("ID").Value == "S_Kunde_Firma")
                                     select SKF.Attribute("Value").Value;
    foreach (string item in skundename)
    {
        string temp = item;
    }
