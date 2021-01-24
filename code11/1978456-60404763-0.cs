    services.Configure<MvcOptions>(options =>
    {
        var xmlSerializerOutputFormatters = options.OutputFormatters
            .OfType<XmlSerializerOutputFormatter>();
        xmlSerializerOutputFormatters.Single()
            .WriterSettings.OmitXmlDeclaration = true;
    });
