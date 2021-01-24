        static void Main(string[] args)
        {
            var xml = @"<Dashboard>...</Dashboard>";
            var document = XDocument.Parse(xml);
            var item = document.XPathSelectElement("//SqlDataSource/Connection[@Name='DEV1']");
            item.SetAttributeValue("ConnectionString", "new value");
            Console.WriteLine(document.ToString());
            //document.Save("");
        }
