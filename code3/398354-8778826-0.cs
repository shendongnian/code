    [Serializable()]
    public struct Coords
    {
        readonly public double x, y, z;
        public Coords(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Coords FromString(string value)
        {
            if (string.IsNullOrEmpty(value)) return new Coords();
            double x = 0,y= 0,z = 0;
            string[] parts = value.Split(',');
            if (parts.Length > 0) double.TryParse(parts[0], out x);
            if (parts.Length > 1) double.TryParse(parts[1], out y);
            if (parts.Length > 2) double.TryParse(parts[2], out z);
            return new Coords(x, y, z);
        }
        public override string ToString()
        {
            //Ensure round-trip formatting
            return string.Format("{0:R},{1:R},{2:R}", x, y, z);
        }
    }
