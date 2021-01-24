    class Program {
        static void Main(string[] args) {
            Console.WriteLine("validando input.xml con input.xsd");
            var schemas = new XmlSchemaSet();
            schemas.Add("", "input.xsd");
            Console.WriteLine("Validando...");
            var custOrdDoc = XDocument.Load("input.xml");
            var errors = false;
            custOrdDoc.Validate(schemas, (o, e) => {
                                     Console.WriteLine("{0}", e.Message);
                                     errors = true;
                                 });
            Console.WriteLine("archivo {0}", errors ? "No cumple con la validacion" : "validacion exitosa");
            Console.ReadKey();
        }
    }
