    String html = "<p class=\"Heading2ANOC\">hello</p><p>world</p>";
    ConverterProperties properties = new ConverterProperties().SetTagWorkerFactory(new CustomTagWorkerFactory());
    IList<IElement> elements = HtmlConverter.ConvertToElements(html, properties);
    foreach (IElement element in elements)
    {
        if (element.HasProperty(CUSTOM_PROPERTY_ID)) {
            String propertyValue = element.GetProperty<String>(CUSTOM_PROPERTY_ID);
            Console.WriteLine(propertyValue);
        }
    }
