    using System;
    using System.IO;
    using System.Linq;
    using ProtoBuf;
    class Program
    {
        static void Main()
        {
            // invent some data
            using (var file = File.Create("data.bin"))
            {
                var rand = new Random(12346);
                for (int i = 0; i < 100000; i++)
                {
                    // nothing special about these numbers other than convenience
                    var next = new MyData { Foo = i, Bar = rand.NextDouble() };
                    Serializer.SerializeWithLengthPrefix(file, next, PrefixStyle.Base128, Serializer.ListItemTag);
                }
            }
            // read it back
            using (var file = File.OpenRead("data.bin"))
            {
                MyData last = null;
                double sum = 0;
                foreach (var item in Serializer.DeserializeItems<MyData>(file, PrefixStyle.Base128, Serializer.ListItemTag)
                    .Take(4000))
                {
                    last = item;
                    sum += item.Foo; // why not?
                }
                Console.WriteLine(last.Foo);
                Console.WriteLine(sum);
            }
        }
    }
     [ProtoContract]
    class MyData
    {
         [ProtoMember(1)]
         public int Foo { get; set; }
         [ProtoMember(2)]
         public double Bar { get; set; }
    }
