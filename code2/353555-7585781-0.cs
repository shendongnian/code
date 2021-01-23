    namespace Alpha
    {
        [ProtoContract]
        [ProtoInclude(1, "Bravo.Implementation, BravoAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
        //[ProtoInclude(1, "Bravo.Implementation")] // this likely only works because they're in the same file
        public class PublicInterface
        {            
        }
    }
    
    namespace  Bravo
    {
        public class Implementation : Alpha.PublicInterface
        {            
        }
    
        public class Tests
        {
            [Test]
            public void X()
            {
                // no real tests; just testing that it runs without exceptions
                Console.WriteLine(typeof(Implementation).AssemblyQualifiedName);
                using (var stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, new Implementation());
                }
            }
        }
    }
