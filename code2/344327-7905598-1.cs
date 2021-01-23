    static void Main(string[] args)
    {
        try
        {
            errors = new ArrayList();
            Saxon.Api.Processor proc = new Processor(true);
            proc.SetProperty(net.sf.saxon.lib.FeatureKeys.VALIDATION_WARNINGS,"true");
            //this is the property to set!
            SchemaManager schemaManager = proc.SchemaManager;
            FileStream xsdFs = new FileStream(@"C:\path\to.xsd", FileMode.Open);
            schemaManager.Compile(XmlReader.Create(xsdFs));
            SchemaValidator schemaValidator = schemaManager.NewSchemaValidator();
            FileStream xmlFs = new FileStream(@"C:\path\to.xml", FileMode.Open);
            
            schemaValidator.SetSource(XmlReader.Create(xmlFs));
            schemaValidator.ErrorList = errors;
            schemaValidator.Run();
        }
        catch(net.sf.saxon.type.ValidationException e)
        {
            foreach(StaticError error in errors)
            {
                Console.WriteLine(error.ToString());
            }
            Console.ReadKey(true);
            Environment.Exit(0);
            
        }
        foreach (StaticError error in errors)
        {
            Console.WriteLine(error.ToString());
        }
        Console.ReadKey(true);
    }
