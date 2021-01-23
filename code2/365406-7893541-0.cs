    using System.Collections.Generic;
    using ProtoBuf;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    
    internal class Program
    {
        private static void Main()
        {
            var foo = new Foo { Bars = new List<Bar>() };
            var rand = new Random(1234);
            for (int i = 0; i < 1000; i++)
            {
                var bar = new Bar
                {
                    A = rand.Next(),
                    B = rand.Next(),
                    C = rand.Next(),
                    D = rand.Next(),
                    E = rand.Next(),
                    F = rand.Next(),
                    G = rand.Next(),
                    H = rand.Next()
                };
                foo.Bars.Add(bar);
            }
            var ms = new MemoryStream();
            Serializer.Serialize(ms, foo);
            var bytes = ms.ToArray();
            const int count = 100000;
            Parallel.For(0, count, x =>
            {
                Serializer.Deserialize<Foo>(new MemoryStream(bytes));
            });
        }
    }
    [ProtoContract]
    internal class Foo
    {
        [ProtoMember(1)]
        public List<Bar> Bars { get; set; }
    }
    [ProtoContract]
    internal class Bar
    {
        [ProtoMember(1)]
        public int A { get; set; }
        [ProtoMember(2)]
        public int B { get; set; }
        [ProtoMember(3)]
        public int C { get; set; }
        [ProtoMember(4)]
        public int D { get; set; }
        [ProtoMember(5)]
        public int E { get; set; }
        [ProtoMember(6)]
        public int F { get; set; }
        [ProtoMember(7)]
        public int G { get; set; }
        [ProtoMember(8)]
        public int H { get; set; }
    }
