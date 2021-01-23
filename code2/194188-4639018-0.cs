    enum PieceTypes
    {
        White,
        Black
    }
    class Box
    {
        public PieceTypes PieceType { get; set; }
        public uint Units { get; set; }
        public int s, p;
        public Box(PieceTypes piecetype, uint units)
        {
            PieceType = piecetype;
            Units = units;
        }
    }
    class Matrix
    {
        public Box[,] Boxes;
        public int Scale, S, P, MaxNum, MaxDist;
        public List<List<Box>> Configurations;
        public Matrix(int s, int p, int scale, int maxnum, int maxdist)
        {
            S = s;
            P = p;
            Scale = scale;
            Boxes = new Box[S, P];
            MaxNum = maxnum;
            MaxDist = maxdist;
            Configurations = new List<List<Box>>();
        }
        public void Find(List<Box> Config, int s, int p)
        {
            // Check the max number thats valid for your configuration
            // Check that the current p and s are inside matrix
            if (Config.Count() < MaxNum && s >= 0 && s < S && p >= 0 && p < P)
            {
                foreach (Box b in Config)
                {
                    if (Valid(b, Boxes[s, p]))
                    {
                        Boxes[s, p].s = s;
                        Boxes[s, p].p = p;
                        Config.Add(Boxes[s, p]);
                        break;
                    }
                }
                Find(Config, s + 1, p);
                Find(Config, s - 1, p);
                Find(Config, s, p + 1);
                Find(Config, s, p - 1);
            }
            if (Config.Count() > 0) Configurations.Add(Config);
            Config.Clear();
        }
        public bool Valid(Box b1, Box b2)
        {
            // Create your dist funtion here
            // or add your extra validation rules like the PieceType
            if (Math.Sqrt((b1.s - b2.s) ^ 2 + (b1.p - b2.p) ^ 2) <= MaxDist && b1.PieceType == b2.PieceType) return true;
            else return false;
        }
    }
