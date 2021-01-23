    public class Test
    {
        [XmlElement("abc")]
        public int Foo { get; set; }
        [XmlIgnore]
        public string Bar { get; set; }
        
        static void Main()
        {
            var props = typeof (Test).GetProperties(
                  BindingFlags.Public | BindingFlags.Instance);
            foreach(var prop in props)
            {
                if(Attribute.IsDefined(prop, typeof(XmlIgnoreAttribute)))
                {
                    Console.WriteLine("Ignore: " + prop.Name);
                    continue; // it is ignored; stop there
                }
                var el = (XmlElementAttribute) Attribute.GetCustomAttribute(
                       prop, typeof (XmlElementAttribute));
                if(el != null)
                {
                    Console.WriteLine("Element: " + (
                      string.IsNullOrEmpty(el.ElementName) ?
                      prop.Name : el.ElementName));
                }
                // todo: repeat for other interesting attributes; XmlAttribute,
                // XmlArrayItem, XmlInclude, etc...
            }
        }
    }
