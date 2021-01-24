    public static void Main(string[] args)
    {
        string xml = File.ReadAllText("C:/Users/Davíð/source/Saxon/Saxon/data.xml");
        string xslt = File.ReadAllText("C:/Users/Davíð/source/Saxon/Saxon/dataXslt.xsl");
        TransformData(xml, xml, xslt);
    }
    static public void TransformData(string xml1, string xml2, string xslt)
    {
        // Create a Processor instance.
        var processor = new Processor();
        // Create a compiled stylesheet
        var compiler = processor.NewXsltCompiler();
        compiler.BaseUri = new Uri("C:/Users/Davíð/source/Saxon/Saxon");
        XsltExecutable templates;
        using (var reader = XmlReader.Create(new StringReader(xslt)))
            templates = compiler.Compile(reader);
        // Note: we could actually use the same Xslt30Transformer in this case.
        // But in principle, the two transformations could be done in parallel in separate threads.
        // Do the first transformation
        Console.WriteLine("\n\n----- transform of " + xml1 + " -----");
        TransformData(processor, templates, xml1, Console.Out);
        // Do the second transformation
        Console.WriteLine("\n\n----- transform of " + xml2 + " -----");
        TransformData(processor, templates, xml2, Console.Out);
    }
    private static void TransformData(Processor processor, XsltExecutable templates, string xml, TextWriter output)
    {
        var transformer = templates.Load30();
        using (var reader = XmlReader.Create(new StringReader(xml)))
        {
            var input = processor.NewDocumentBuilder().Build(reader);
            transformer.ApplyTemplates(input, processor.NewSerializer(output));
        }
    }
