    var instructions = (from item in config.Elements("import")
    select new
    {
        name = item.Attribute("name").Value,
        watchFolder = item.Attribute("watchFolder").Value,
        root = item.Element("documentRoot").Value,
        DocumentNameDynamic = item.Element("documentName").Attribute("xpath").Value,
        DocumentNameStatic = item.Element("documentName").Attribute("static").Value,
        TemplateName = item.Element("template").Attribute("template").Value,
        Path = item.Element("path").Attribute("path").Value,
        fields = item.Element("fields").Elements().Select(item => new {
            xpath = item.Attribute("xpath").Value,
            FieldName = item.Attribute("FieldName").Value,
            isMultiValue = bool.Parse(item.Attribute("multiValue").Value)
        }
    ).SingleOrDefault();
