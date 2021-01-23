        interface IXElementConvertible
        {
            void LoadFrom(XElement element);
        }
        class Book : IXElementConvertible
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Author { get; set; }
            public void LoadFrom(XElement element)
            {
                this.Name = element.Attribute("Name").Value;
                //blabla
            }
        }
