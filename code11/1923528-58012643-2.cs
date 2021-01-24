    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    namespace Serializator
    {
        public class Serializator
        {
            public Object ReadToObject(string json, Type t)
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
        };
        [DataContract]
        public class ErrorClass
        {
            [DataMember] public string ErrorCode { get; set; }
            [DataMember] public string ErrorMessage { get; set; }
        };
        class Program
        {
            static void Main(string[] args)
            {
                Serializator ser = new Serializator();
                IntermediateClass ic = (IntermediateClass)ser.ReadToObject("{\"error\":\"{\\n \\\"ErrorCode\\\" : 0,\\n \\\"ErrorMessage\\\" : \\\"Success.\\\"\\n}\\n\",\"group\":[\"{\\n \\\"ID\\\" : 1,\\n \\\"Name\\\" : \\\"Student1\\\"\\n}\\n\",\"{\\n \\\"ID\\\" : 2,\\n \\\"Name\\\" : \\\"Student2\\\"\\n}\\n\"]}", typeof(IntermediateClass));
                ErrorClass ec = (ErrorClass)ser.ReadToObject(ic.error, typeof(ErrorClass));
                Console.WriteLine(ec.ErrorCode);
                Console.WriteLine(ec.ErrorMessage);
            }
        }
    }
