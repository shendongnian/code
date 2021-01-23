    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
            var obj = new ClassToSerialize
            {
                PrimaryExc = 'a', 
                NoResults = true
            };
    
            var serializer 
                = new DataContractJsonSerializer(typeof(ClassToSerialize));
    
            var ms = new MemoryStream();
            
            serializer.WriteObject(ms, obj);
    
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
    
    [DataContract]
    [Serializable]
    public class ClassToSerialize
    {
        [NonSerialized]
        private bool _mf;
    
        public bool IsMf
        {
            get { return _mf; }
            set { _mf = value; }
        }
    
        [DataMember]
        public bool NoResults { get; set; }
    
        [DataMember]
        public char PrimaryExc { get; set; }
    }
