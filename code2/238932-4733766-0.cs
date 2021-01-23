    private void ChangeCustomFilePropertiesPart(CustomFilePropertiesPart customFilePropertiesPart)
    {
        var props = from n in customFilePropertiesPart.Properties.Elements<CustomProperties.CustomDocumentProperty>()
                    where n.Name == "filePath" || n.Name == "templateFilePath"
                    select n;
                
        foreach (var prop in props)
        {
            VariantTypes.VTLPWSTR value = prop.GetFirstChild<VariantTypes.VTLPWSTR>();
            value.Text = "";
        }
    }
