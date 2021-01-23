        class Program
        {
            [DataContract]
            public class A
            {
                public int Id { get; set; }
            }
    
            [DataContract]
            public class B : A
            {
    
            }
    
            static void Main(string[] args)
            {
                A instance = new B { Id = 42 };
    
                var dataContractSerializer = new DataContractSerializer(typeof(A), new List<Type>() { typeof(B) });
                var xmlOutput = new StringBuilder();
                using (var writer = XmlWriter.Create(xmlOutput))
                {
                    dataContractSerializer.WriteObject(writer, instance);
                }
    
            }
        }
