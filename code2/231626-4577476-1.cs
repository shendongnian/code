    public struct Coordinate : IEquatable<Coordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
    public class Data
    {
        // Map data goes here.
    }
    public class Chunk
    {
        public Coordinate Origin { get; set; }
        public Data[,] Data { get; set; }
        public Data this[Coordinate coord]
        {
            get { return Data[coord.X - Origin.X, coord.Y - Origin.Y]; }
            set { Data[coord.X - Origin.X, coord.Y - Origin.Y] = value; }
        }
    }
    public class Map
    {
        private Dictionary<Coordinate, Chunk> map = new Dictionary<Coordinate,Chunk>();
        public Data this[Coordinate coord]
        {
            get
            {
                Chunk chunk = LoadChunk(coord);
                return chunk[coord];
            }
            set
            {
                Chunk chunk = LoadChunk(coord);
                chunk[coord] = value;
            }
        }
        private Chunk LoadChunk(Coordinate coord)
        {
            Coordinate origin = GetChunkOrigin(coord);
            if (map.ContainsKey(origin))
            {
                return map[origin];
            }
            CheckUnloadChunks();
            Chunk chunk = new Chunk { Origin = origin, Data = new Data[16, 16] };
            map.Add(origin, chunk);
            return chunk;
        }
        private void CheckUnloadChunks()
        {
            // Unload old chunks.
        }
        private Coordinate GetChunkOrigin(Coordinate coord)
        {
            return new Coordinate { X = coord.X / 16 * 16, Y = coord.Y / 16 * 16 };
        }
    }
