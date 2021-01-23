    XmlNodeList list = Populate();
    list.OfType<XmlNode>()
        .Select(n =>
            new
            {
                Column1 = n.Atttributes["val1"].Value,
                Column2 = n.Atttributes["val1"].Value
            });
