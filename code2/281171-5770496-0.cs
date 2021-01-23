    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class Attributes
    {
        public string name { get; set; }
        public string[] data { get; set; }
        public string[] dataName { get; set; }
        public string[] dataValue { get; set; }
        public string toClick { get; set; }
    }
    
    
    public class DataJsonAttributeContainer
    {
        public List<Attributes> attributes { get; set; }
    }
    
    class Test
    {
    
        public static T DeserializeFromJson<T>(string json)
        {
            T deserializedProduct = JsonConvert.DeserializeObject<T>(json);
            return deserializedProduct;
        }
        
        static void Main()
        {
            string JsonStr =
                "{\"attributes\":[{\"name\":\"a\",\"data\":[\"10\",\"0\",\"50\"],\"dataName\":[\"2000248\",\"2789290\",\"2789291\"],\"dataValue\":[\"a\",\"a\",\"d\"],\"toClick\":\"d\"},{\"name\":\"d\",\"data\":[\"0\",\"0\",\"0\",\"20\"],\"dataName\":[\"49500000\",\"49500001\",\"49500002\",\"49500003\"],\"dataValue\":[\"a\",\"a\",\"d\",\"d\"],\"toClick\":\"a\"}]}";
            var container = DeserializeFromJson<DataJsonAttributeContainer>(JsonStr);
            Console.WriteLine(container.attributes.Count); // Prints 2
            Console.WriteLine(container.attributes[0].data.Length); // Prints 3
        }
    }
