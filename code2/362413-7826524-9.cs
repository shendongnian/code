        private List<Rectangle> _rects = new List<Rectangle>();
        private void GenerateRects()
        {
            int width = 300; // or whatever dimensions...
            int height = 300;
            int gridSize = 50;
            for (int x = 0; x < width; x += gridSize)
            {
                for (int y = 0; y < height; y += gridSize)
                {
                    var rect = new Rectangle
                    {
                        Opacity = 0,
                        Width = Math.Min(gridSize, width - x),
                        Height = Math.Min(gridSize, height - y),
                    };
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    _rects.Add(rect);
                    this.paint.Children.Add(rect);
                }
            }
        }
