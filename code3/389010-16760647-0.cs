     [Test]
        public void CompareXPathNavigatorToXPathSelectElement()
        {     
            var max = 100000;
    
            Stopwatch watch = new Stopwatch();
            watch.Start();
    
            bool parseChildNodeValues = true;
    
            ParseUsingXPathNavigatorSelect(max, watch, parseChildNodeValues);
            ParseUsingXElementElements(watch, max, parseChildNodeValues);
            ParseUsingXElementXPathSelect(watch, max, parseChildNodeValues);
            ParseUsingXPathNavigatorFromXElement(watch, max, parseChildNodeValues);
        }
    
        private static void ParseUsingXPathNavigatorSelect(int max, Stopwatch watch, bool parseChildNodeValues)
        {
            var document = new XPathDocument(@"data\books.xml");
            var navigator = document.CreateNavigator();
    
            for (var i = 0; i < max; i++)
            {
                var books = navigator.Select("/catalog/book");
                while (books.MoveNext())
                {
                    var location = books.Current;
                    var book = new Book();
                    book.Id = location.GetAttribute("id", "");
    
                    if (!parseChildNodeValues) continue;
    
                    book.Title = location.SelectSingleNode("title").Value;
                    book.Genre = location.SelectSingleNode("genre").Value;
                    book.Price = location.SelectSingleNode("price").Value;
                    book.PublishDate = location.SelectSingleNode("publish_date").Value;
                    book.Author = location.SelectSingleNode("author").Value;
                }
            }
    
            watch.Stop();
            Console.WriteLine("Time using XPathNavigator.Select = " + watch.ElapsedMilliseconds);
        }
    
        private static void ParseUsingXElementElements(Stopwatch watch, int max, bool parseChildNodeValues)
        {
            watch.Restart();
            var element = XElement.Load(@"data\books.xml");
    
            for (var i = 0; i < max; i++)
            {
                var books = element.Elements("book");
                foreach (var xElement in books)
                {
                    var book = new Book();
                    book.Id = xElement.Attribute("id").Value;
    
                    if (!parseChildNodeValues) continue;
    
                    book.Title = xElement.Element("title").Value;
                    book.Genre = xElement.Element("genre").Value;
                    book.Price = xElement.Element("price").Value;
                    book.PublishDate = xElement.Element("publish_date").Value;
                    book.Author = xElement.Element("author").Value;
                }
            }
    
            watch.Stop();
            Console.WriteLine("Time using XElement.Elements = " + watch.ElapsedMilliseconds);
        }
    
        private static void ParseUsingXElementXPathSelect(Stopwatch watch, int max, bool parseChildNodeValues)
        {
            XElement element;
            watch.Restart();
            element = XElement.Load(@"data\books.xml");
    
            for (var i = 0; i < max; i++)
            {
                var books = element.XPathSelectElements("book");
                foreach (var xElement in books)
                {
                    var book = new Book();
                    book.Id = xElement.Attribute("id").Value;
    
                    if (!parseChildNodeValues) continue;
    
                    book.Title = xElement.Element("title").Value;
                    book.Genre = xElement.Element("genre").Value;
                    book.Price = xElement.Element("price").Value;
                    book.PublishDate = xElement.Element("publish_date").Value;
                    book.Author = xElement.Element("author").Value;
                }
            }
    
            watch.Stop();
            Console.WriteLine("Time using XElement.XpathSelectElement = " + watch.ElapsedMilliseconds);
        }
    
        private static void ParseUsingXPathNavigatorFromXElement(Stopwatch watch, int max, bool parseChildNodeValues)
        {
            XElement element;
            watch.Restart();
            element = XElement.Load(@"data\books.xml");
    
            for (var i = 0; i < max; i++)
            {
                // now we can use an XPath expression
                var books = element.CreateNavigator().Select("book");
    
                while (books.MoveNext())
                {
                    var location = books.Current;
                    var book = new Book();
                    book.Id = location.GetAttribute("id", "");
    
                    if (!parseChildNodeValues) continue;
    
                    book.Title = location.SelectSingleNode("title").Value;
                    book.Genre = location.SelectSingleNode("genre").Value;
                    book.Price = location.SelectSingleNode("price").Value;
                    book.PublishDate = location.SelectSingleNode("publish_date").Value;
                    book.Author = location.SelectSingleNode("author").Value;
                }
            }
    
            watch.Stop();
            Console.WriteLine("Time using XElement.Createnavigator.Select = " + watch.ElapsedMilliseconds);
        }
