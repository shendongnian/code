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
            static public Object ReadToObject(string json, Type t)
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(t);
                var deserialized = ser.ReadObject(ms);
                ms.Close();
                return deserialized;
            }
        }
        [DataContract]
        public class IntermediateClass
        {
            [DataMember] public string error { get; set; }
            [DataMember] public List<string> group { get; set; }
        };
        [DataContract]
        public class ErrorClass
        {
            [DataMember] public string ErrorCode { get; set; }
            [DataMember] public string ErrorMessage { get; set; }
        };
        public class GroupClass
        {
            [DataMember] public int ID { get; set; }
            [DataMember] public string Name { get; set; }
        }
        public class CombinedClass
        {
            public ErrorClass error { get; set; }
            public List<GroupClass> group { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                CombinedClass cb = new CombinedClass();
                IntermediateClass ic = (IntermediateClass)Serializator.ReadToObject("{\"error\":\"{\\n \\\"ErrorCode\\\" : 0,\\n \\\"ErrorMessage\\\" : \\\"Success.\\\"\\n}\\n\",\"group\":[\"{\\n \\\"ID\\\" : 1,\\n \\\"Name\\\" : \\\"Student1\\\"\\n}\\n\",\"{\\n \\\"ID\\\" : 2,\\n \\\"Name\\\" : \\\"Student2\\\"\\n}\\n\"]}", typeof(IntermediateClass));
                cb.group = new List<GroupClass>();
                foreach (var item in ic.group)
                {
                    cb.group.Add((GroupClass)Serializator.ReadToObject(item, typeof(GroupClass)));
                }
                cb.error = (ErrorClass)Serializator.ReadToObject(ic.error, typeof(ErrorClass));
                Console.WriteLine(cb.error.ErrorCode);
                Console.WriteLine(cb.error.ErrorMessage);
                Console.WriteLine(cb.group[0].Name);
                Console.WriteLine(cb.group[0].ID);
                Console.WriteLine(cb.group[1].Name);
                Console.WriteLine(cb.group[1].ID);
            }
        }
    }
