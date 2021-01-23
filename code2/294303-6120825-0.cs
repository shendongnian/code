    XmlReader reader = XmlReader.Create(new StringReader(spfield.SchemaXml));
    XmlDocument doc = new XmlDocument();
    XmlNode node = doc.ReadNode(reader);
    string curSymbol = "";
    if (node.Attributes["LCID"] != null)
    {
        string lcidValue = node.Attributes["LCID"].Value;
        foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {
            if (ci.LCID.ToString() == lcidValue)
            {
                curSymbol = ci.NumberFormat.CurrencySymbol;
                break;
            }
        }
    }
    field.HtmlEncode = false;
    field.DataFormatString = curSymbol + " {0:#,###.##}";
