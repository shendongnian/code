    class Polyhedron
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
    
        public int AllDimensions
        {
            set { Height = Width = Depth = value; }
        }
    }
