        public class ProductXml
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            private string Color { get; set; }
            private string Country { get; set; }
            private string Brand { get; set; }
            [XmlElement(ElementName = "Property")]
            public List<Property> property
            {
                get {
                    return new List<Property>() {
                        new Property() { Name = "color", Text = Color},
                        new Property() { Name = "country", Text = Country},
                        new Property() { Name = "brand", Text = Brand},
                    };          
                }
                set {
                    foreach (Property prop in value)
                    {
                        switch (prop.Name)
                        {
                            case "color" :
                                Color = prop.Text;
                                break;
                            case "country":
                                Country = prop.Text;
                                break;
                            case "brand":
                                Brand = prop.Text;
                                break;
                        }
                    }
                }
            }
        }
        [XmlRoot(ElementName = "property")]
        public class Property
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
