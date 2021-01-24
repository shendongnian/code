    public class Room
    {
        public int length;
        public int height;
        public int width;
        // those can be calculated so I would declare readonly properties with get-only
        public int area { get { return width*length; } }
        public int wallArea { get { return  length * height; } }
        public int ceilingArea { get { return  width * length; } }
    }
