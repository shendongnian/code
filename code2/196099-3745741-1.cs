    interface BoundingVolume
    {
        bool CollidesWith(BoundingVolume v);
        bool CollidesWith(BoundingBox b);
        bool CollidesWith(BoundingSphere s);
    }
    class BoundingBox : BoundingVolume
    {
        public bool CollidesWith(BoundingVolume v)
        {
            return v.CollidesWith(this);
        }
        public bool CollidesWith(BoundingBox b)
        {
            Console.WriteLine("box/box");
            return true;
        }
        public bool CollidesWith(BoundingSphere s)
        {
            Console.WriteLine("box/sphere");
            return true;
        }
    }
    
    class BoundingSphere : BoundingVolume
    {
        public bool CollidesWith(BoundingVolume v)
        {
            return v.CollidesWith(this);
        }
        public bool CollidesWith(BoundingBox b)
        {
            Console.WriteLine("sphere/box");
            return true;
        }
        public bool CollidesWith(BoundingSphere s)
        {
            Console.WriteLine("sphere/sphere");
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BoundingVolume v1 = new BoundingBox();
            BoundingVolume v2 = new BoundingSphere();
            Console.WriteLine(v1.CollidesWith(v2));
        }
    }
