    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    namespace Serializator
    {
        public class Serializator
        {
            static public SomeClass ReadToObject(string json)
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SomeClass));
                var deserialized = ser.ReadObject(ms) as SomeClass;
                ms.Close();
                return deserialized;
            }
        }
        [DataContract]
        public class SomeClass
        {
            [DataMember] public string key1 { get; set; }
            [DataMember] public List<string> key2 { get; set; }
        };
        class Program
        {
            static void Main(string[] args)
            {
                SomeClass sc = Serializator.ReadToObject("{\"key1\":\"value1\", \"key2\":[\"arrayValue1\", \"arrayValue2\", \"arrayValue3\"]}");
                foreach(var item in sc.key2)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
