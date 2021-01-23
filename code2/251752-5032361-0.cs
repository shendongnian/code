    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Web.Script.Serialization;
    using System.Collections.ObjectModel;
    
    namespace ConsoleApplication1
    {
        [Serializable]
        public class Thing
        {
            public string Foo { get; set; }
            public string Bar { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var json = "{\"Foo\":\"some string\",\"Bar\":{\"Quux\":23}}";
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] {
                    new StringConverter()           
                });
                var thing = serializer.Deserialize<Thing>(json);
    
                Console.WriteLine(thing.Bar);
            }
        }
    
        public class StringConverter : JavaScriptConverter
        {
            public override IEnumerable<Type> SupportedTypes
            {
                get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(string) })); }
            }
    
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                var i = dictionary.First();
                return "{ \"" + i.Key + "\" : " + i.Value + " }";
            }
        }
    }
