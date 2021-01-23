    public class Base
    {
        [XmlIgnore]
        public virtual  string Name { get; set; }
    }
    public class Derived : Base
    {
        [XmlIgnore] //Remove this to include
        public override string Name { get; set; }
    }
    MemoryStream memStream = new MemoryStream();
    XmlSerializer xmlSer = new XmlSerializer(typeof(Derived));
    xmlSer.Serialize(memStream, new Derived() { Name = "aaaa" });
    MessageBox.Show(Encoding.UTF8.GetString(memStream.ToArray()));
