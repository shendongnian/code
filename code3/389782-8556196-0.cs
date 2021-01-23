    private string Merge(ManualTypeEnum manualType, Object mergeValues)
    {
        var body = "";
        var templateFile = string.Format("{0}MailTemplate.vm", manualType);
        var velocity = new VelocityEngine();
        var props = new ExtendedProperties();
        props.AddProperty("file.resource.loader.path", Config.EmailTemplatePath);
        velocity.Init(props);
        var template = velocity.GetTemplate(templateFile);
        var context = new VelocityContext();
        context.Put("Change", mergeValues);
        using (var writer = new StringWriter())
        {
            template.Merge(context, writer);
            body = writer.ToString();
        }
        return body;
    }
