    class Program
    {
        static void Main(string[] args)
        {
            FileInfo xmlFile = new FileInfo(@"Resources\TestFile.xml");
            FileInfo transformFile = new FileInfo(@"Resources\TestFileTransform.xslt");
            FileInfo prettyFile = new FileInfo(@"Resources\PrettyFile.xml");
    
            if (xmlFile.Exists && transformFile.Exists)
            {
                // Perform transform operations.
                XslCompiledTransform trans = new XslCompiledTransform();
                trans.Load(transformFile.FullName);
                trans.Transform(xmlFile.FullName, prettyFile.FullName);
            }
    
            if (prettyFile.Exists)
            {
                // Deserialize the new information.
                XmlSerializer serializer = new XmlSerializer(typeof(TestFile));
                XDocument doc = XDocument.Load(prettyFile.FullName);
                TestFile o = (TestFile)serializer.Deserialize(doc.CreateReader());
    
                // Show the results.
                foreach (Parameter p in o.Parameters)
                {
                    Console.WriteLine("{0}: {1}", p.ObjectType, p.ObjectValue);
                }
            }
    
            // Pause for effect.
            Console.ReadKey();
        }
    }
