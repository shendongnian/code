    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.ComponentModel;
    public abstract class BaseClass
    {}
    public class FirstChild:BaseClass
    {}
    public class SecondChild:BaseClass
    {}
    [XmlRoot("Request")]
    [XmlType("Request")]
    public class RequestMemento
    {
        [DefaultValue(null)]
        public FirstChild First { get; set; }
        [DefaultValue(null)]
        public SecondChild Second { get; set; }
        [XmlIgnore]
        public BaseClass Child
        {
            get
            {
                return (BaseClass)First ?? (BaseClass)Second;
            }
            set
            {
                First = value as FirstChild;
                Second = value as SecondChild;
            }
        }
    }
    class App
    {
        static void Main()
        {
            var memento = new RequestMemento();
            memento.Child = new FirstChild();
            XmlSerializer serializer = new XmlSerializer(typeof(RequestMemento));
            using (var writer = new StreamWriter("1.xml"))
            {
                serializer.Serialize(writer, memento);
            }
        }
    }
