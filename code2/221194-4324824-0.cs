    struct ColumnHeadings
    {
        private readonly string name;
        private readonly int width;
        public string Name { get { return name; } }
        public int Width { get { return width; } }
        public ColumnHeadings(string name, int width)
        {
            this.name = name;
            this.width = width;
        }
    }
