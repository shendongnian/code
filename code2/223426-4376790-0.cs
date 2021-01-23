    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Configuration;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                  var section = (MySection)ConfigurationManager.GetSection("MySection");
    
                Console.WriteLine("Done");
            }
        }
    
        public class MySection : ConfigurationSection
        {
            [ConfigurationProperty("name", IsKey = true, DefaultValue = "", IsRequired = true)]
            public string Name
            {
                get { return (string)this["name"]; }
                set { this["name"] = value; }
            }
    
            [ConfigurationProperty("value")]
            public string Value
            {
                get { return (string)this["value"]; }
                set { this["value"] = value; }
            }
    
        }
    
        public class MyCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new MyElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((MyElement)element).Name;
            }
        }
    
        public class MyElement : ConfigurationElement
        {
            [ConfigurationProperty("name", IsKey = true, DefaultValue = "", IsRequired = true)]
            public string Name
            {
                get { return (string)this["name"]; }
                set { this["name"] = value; }
            }
    
            [ConfigurationProperty("value")]
            public string Value
            {
                get { return (string)this["value"]; }
                set { this["value"] = value; }
            }
    
    
        }
    }
