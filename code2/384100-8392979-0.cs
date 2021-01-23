    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ProtoBuf;
    class Program
    {
        static void Main()
        {
            var data = new Data
            {
                Points =
                {
                    {new DateTime(2009,09,1,0,0,0), 11.04F},
                    {new DateTime(2009,09,1,0,15,0), 11.04F},
                    {new DateTime(2009,09,1,0,30,0), 11.01F},
                    {new DateTime(2009,09,1,0,45,0), 11.01F},
                    {new DateTime(2009,09,1,1,0,0), 11F},
                    {new DateTime(2009,09,1,1,15,0), 10.98F},
                    {new DateTime(2009,09,1,1,30,0), 10.98F},
                    {new DateTime(2009,09,1,1,45,0), 10.92F},
                    {new DateTime(2009,09,1,2,00,0), 10.09F},
                }
            };
    
            var ms = new MemoryStream();
            Serializer.Serialize(ms, data);
            ms.Position = 0;
            var clone =Serializer.Deserialize<Data>(ms);
            Console.WriteLine("{0} points:", clone.Points.Count);
            foreach(var pair in clone.Points.OrderBy(x => x.Key))
            {
                float orig;
                data.Points.TryGetValue(pair.Key, out orig);
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value == orig ? "correct" : "FAIL");
            }
        }
    }
    [ProtoContract]
    class Data
    {
        private readonly Dictionary<DateTime, float> points = new Dictionary<DateTime, float>();
        [ProtoMember(1)]
        public Dictionary<DateTime, float> Points { get { return points; } } 
    }
