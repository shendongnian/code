    using System.Collections.Generic;
    using System.IO;
    using ProtoBuf;
    [ProtoContract]
    class Line
    {
        private readonly List<Point> points = new List<Point>();
        [ProtoMember(1, DataFormat = DataFormat.Group)]
        public List<Point> Points { get { return points; } }
    }
    [ProtoContract]
    class Point
    {
        [ProtoMember(1)]
        public int X { get; set; }
        [ProtoMember(2)]
        public int Y { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            var lines = new List<Line> {
                new Line { Points = {
                       new Point { X = 1, Y = 2}
                }},
                new Line { Points = {
                       new Point { X = 3, Y = 4},
                       new Point { X = 5, Y = 6}
                }},
            };
            byte[] raw;
            // serialize
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, lines);
                raw = ms.ToArray();
            }
            List<Line> clone;
            // deserialize
            using (var ms = new MemoryStream(raw))
            {
                clone = Serializer.Deserialize<List<Line>>(ms);
            }
        }
    }
