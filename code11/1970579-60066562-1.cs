    [XmlRoot(ElementName = "picture")]
        public class Picture
        {
            [XmlElement(ElementName = "id")]
            public string Id { get; set; }
            [XmlElement(ElementName = "name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "size")]
            public string Size { get; set; }
            [XmlElement(ElementName = "price")]
            public string Price { get; set; }
            [XmlElement(ElementName = "quantity")]
            public string Quantity { get; set; }
            [XmlElement(ElementName = "sizes")]
            public Sizes Sizes { get; set; }
        }
        [XmlRoot(ElementName = "pictures")]
        public class Pictures
        {
            [XmlElement(ElementName = "picture")]
            public List<Picture> Picture { get; set; }
        }
        [XmlRoot(ElementName = "set")]
        public class Set
        {
            [XmlElement(ElementName = "name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "price")]
            public string Price { get; set; }
            [XmlElement(ElementName = "pictures")]
            public Pictures Pictures { get; set; }
        }
        [XmlRoot(ElementName = "sets")]
        public class Sets
        {
            [XmlElement(ElementName = "set")]
            public List<Set> Set { get; set; }
        }
        [XmlRoot(ElementName = "size")]
        public class Size
        {
            [XmlElement(ElementName = "id")]
            public string Id { get; set; }
            [XmlElement(ElementName = "name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "price")]
            public string Price { get; set; }
        }
        [XmlRoot(ElementName = "sizes")]
        public class Sizes
        {
            [XmlElement(ElementName = "size")]
            public List<Size> Size { get; set; }
        }
        [XmlRoot(ElementName = "data")]
        public class Data
        {
            [XmlElement(ElementName = "sets")]
            public Sets Sets { get; set; }
            [XmlElement(ElementName = "pictures")]
            public Pictures Pictures { get; set; }
        }
and use the following to deserialize
var ser = new XmlSerializer(typeof(Data));
var data = (Data)ser.Deserialize(new StringReader(xmlString));
List<Set> lstSets = data.Sets.Set;
List<Picture> lstPictures = data.Pictures.Picture;
If you are ever unsure about the classes and their structure in C#, use [xml2CSharp](www.xml2csharp.com) site to generate the classes with element tags.
