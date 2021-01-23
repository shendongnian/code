        private List<Rect> _rects = new List<Rect>();
        private void GenerateRects()
        {
            int width = 300; // or whatever size...
            int height = 300;
            int gridSize = 50;
            for (int x = 0; x < width; x += gridSize)
            {
                for (int y = 0; y < height; y += gridSize)
                {
                    var rect = new Rect(
                        new Point(x, y), 
                        new Point(Math.Min(x + gridSize, width), Math.Min(y + gridSize, height))
                        );
                    _rects.Add(rect);
                }
            }
        }
