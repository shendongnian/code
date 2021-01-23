    class House : IRectangular
    {
        int width;
        int height;
        public House(int w, int h)
        { width = w; height = h; }
        public int Width() { return width; }
        public int Height() { return height; }
    }
