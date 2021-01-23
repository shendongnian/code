    public sealed class Program {
        public static void Main() {
            var tiles = new List<Point>();
            tiles.Add(new Point { X = 5, Y = 10 });
            tiles[0].X = 15;
        }
    }
