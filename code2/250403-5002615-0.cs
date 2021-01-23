    using System;
    using System.IO;
    using ProtoBuf;
    [ProtoContract]
    class Foo
    {
        [ProtoMember(1)]
        public int A { get; set; }
    }
    [ProtoContract]
    class Bar
    {
        [ProtoMember(1)]
        public int B { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            using (var ms = new MemoryStream())
            {
                Serializer.SerializeWithLengthPrefix(ms, new Foo { A = 1 }, PrefixStyle.Base128, 1);
                Serializer.SerializeWithLengthPrefix(ms, new Bar { B = 2 }, PrefixStyle.Base128, 2);
                Serializer.SerializeWithLengthPrefix(ms, new Foo { A = 3 }, PrefixStyle.Base128, 1);
                Serializer.SerializeWithLengthPrefix(ms, new Bar { B = 4 }, PrefixStyle.Base128, 2);
                ms.Position = 0;
    
                // we want all the Bar - so we'll use a callback that says "Bar" for 2, else null (skip)
                object obj;
                while (Serializer.NonGeneric.TryDeserializeWithLengthPrefix(ms, PrefixStyle.Base128,
                    tag => tag == 2 ? typeof(Bar) : null, out obj))
                {
                    Console.WriteLine(((Bar)obj).B);
                }
            }
        }
    }
