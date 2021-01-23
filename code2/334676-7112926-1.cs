    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = Shape.Create(args[0]);
        }
    }
    public abstract class Shape
    {
        protected Shape(string filename) { ...  }
        public abstract float Volume { get; }
        public static Shape Create(string filename)
        {
            string ext = Path.GetExtension(filename);
            // read file here
            switch (ext)
            {
                case ".box":
                    return new BoxShape(filename);
                case ".sphere":
                    return new SphereShape(filename);
            }
            return null;
        }
        class BoxShape : Shape
        {
            public BoxShape(string filename)
                : base(filename)
            {
                // Parse contents 
            }
            public override float Volume { get { return ... } }
        }
        class SphereShape : Shape
        {
            float radius;
            public SphereShape(string filename)
                : base(filename)
            {
                // Parse contents
            }
            public override float Volume { get { return ... } }
        }
    }
