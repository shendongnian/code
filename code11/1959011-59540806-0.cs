        public static void CopyManyUiElementToClipboard(List<FrameworkElement> elements)
        {
            double totalWidth = elements.First().ActualWidth;
            double totalHeight = elements.Sum(element => element.ActualHeight);
            var size = new Size(totalWidth, totalHeight);
            var rectangleFrame = new Rectangle
            {
                Width = (int)size.Width,
                Height = (int)size.Height,
                Fill = Brushes.White
            };
            rectangleFrame.Arrange(new Rect(size));
            var renderBitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96d, 96d, PixelFormats.Pbgra32);
            renderBitmap.Render(rectangleFrame);
            var yPointCordinate = 0.0;
            elements.ForEach(element =>
            {
                var drawingContext = new DrawingVisual();
                using (DrawingContext draw = drawingContext.RenderOpen())
                {
                    var visualBrush = new VisualBrush(element);
                    var elementSize = new Size(element.ActualWidth, element.ActualHeight);
                    draw.DrawRectangle(visualBrush, null, new Rect(new Point(0, yPointCordinate), elementSize));
                }
                yPointCordinate += element.ActualHeight;
                renderBitmap.Render(drawingContext);
            });
            Clipboard.SetImage(renderBitmap);
        }
