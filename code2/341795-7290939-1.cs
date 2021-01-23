    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Testing));
            string serializedString;
            Testing instance = new Testing();
            using (StringWriter writer = new StringWriter())
            {
                instance.SomeProperty = true;
                serializer.Serialize(writer, instance);
                serializedString = writer.ToString();
            }
            Console.WriteLine("Serialized instance with SomeProperty={0} out as {1}", instance.SomeProperty, serializedString);
            using (StringReader reader = new StringReader(serializedString))
            {
                instance = (Testing)serializer.Deserialize(reader);
                Console.WriteLine("Deserialized string {0} into instance with SomeProperty={1}", serializedString, instance.SomeProperty);
            }
            Console.ReadLine();
        }
    }
    public class Testing
    {
        [DefaultValue(true)]
        public bool SomeProperty { get; set; }
    }
