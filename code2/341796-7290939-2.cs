    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using System.IO;
    class Program
    {
        private static string[] s_inputs = new[]
        {
            @"<?xml version=""1.0"" encoding=""utf-16""?>
              <Testing xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" />",
            @"<?xml version=""1.0"" encoding=""utf-16""?>
              <Testing xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  	              <SomeProperty />
              </Testing>",
  
            @"<?xml version=""1.0"" encoding=""utf-16""?>
              <Testing xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  	              <SomeProperty>true</SomeProperty>
              </Testing>",
        };
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Testing));
            foreach (var input in s_inputs)
            {
                using (StringReader reader = new StringReader(input))
                {
                    Testing instance = (Testing)serializer.Deserialize(reader);
                    Console.WriteLine("Deserialized string \n{0}\n into instance with SomeProperty={1}", input, instance.SomeProperty);
                }
            }
            Console.ReadLine();
        }
    }
    public class Testing
    {
        [DefaultValue(true)]
        public bool SomeProperty { get; set; }
    }
