            var xml = ... XML from your post ...;
            var xmlReader = XmlReader.Create( new StringReader(xml) ); // Or whatever your source is, of course.
            var myXDocument = XDocument.Load( xmlReader );
            var namespaceManager = new XmlNamespaceManager( xmlReader.NameTable ); // We now have a namespace manager that knows of the namespaces used in your document.
            namespaceManager.AddNamespace( "prefix", "http://www.MyNamespace.ca/MyPath" ); // We add an explicit prefix mapping for our query.
            var result = myXDocument.XPathSelectElement(
                "//prefix:Plugin/prefix:UI[1]/prefix:PluginPageCategory[1]/prefix:Page[1]/prefix:Group[1]/prefix:CommandRef[2]",
                namespaceManager
            ); // We use that prefix against the elements in the query.
            Console.WriteLine(result); // <CommandRef ...> element is printed.
