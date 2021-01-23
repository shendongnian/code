    Assembly asm = Assembly.GetExecutingAssembly();
    string assemblyName = asm.GetName().Name;
    string emailTemplateName = xyz.tt;
    emailTemplateName = assemblyName + "." +  emailTemplateName;
    using (StreamReader reader = new StreamReader(asm.GetManifestResourceStream(emailTemplateName)))
    {
    body = reader.ReadToEnd();
    }
