    string templateDir = HttpContext.Current.Server.MapPath("Templates");
    string templateName = "SimpleTemplate.vm";
    INVelocityEngine fileEngine = 
        NVelocityEngineFactory.CreateNVelocityFileEngine(templateDir, true);
    IDictionary context = new Hashtable();
    context.Add(parameterName , value);
    var output = fileEngine.Process(context, templateName);
