    public static class BitmapFont
    {
        private class FontInfo
        {
            public FontInfo(WriteableBitmap image, Dictionary<char, Rect> metrics)
            {
                this.Image = image;
                this.Metrics = metrics;
            }
            public WriteableBitmap Image { get; private set; }
            public Dictionary<char, Rect> Metrics { get; private set; }
        }
        private static Dictionary<string, FontInfo> fonts = new Dictionary<string, FontInfo>();
        public static void RegisterFont(string fontFile, string fontMetricsFile)
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(fontFile);
            BitmapImage image = new BitmapImage();
            
            image.SetSource(App.GetResourceStream(new Uri(fontFile,UriKind.Relative)).Stream);
            var metrics = XDocument.Load(fontMetricsFile);
            var dict = (from c in metrics.Root.Elements()
                        let key = (char)((int)c.Attribute("key"))
                        let rect = new Rect((int)c.Element("x"), (int)c.Element("y"), (int)c.Element("width"), (int)c.Element("height"))
                        select new { Char = key, Metrics = rect }).ToDictionary(x => x.Char, x => x.Metrics);
            fonts.Add(name,new FontInfo(new WriteableBitmap(image),dict));
        }
        public static WriteableBitmap DrawFont(string text, string fontName)
        {
            var font = fonts[fontName];
            var letters = text.Select(x => font.Metrics[x]).ToArray();
            var height = (int)letters.Max(x => x.Height);
            var width = (int)letters.Sum(x => x.Width);
            WriteableBitmap bmp = new WriteableBitmap(width, height);
            int[] source = font.Image.Pixels, dest = bmp.Pixels;
            int sourceWidth = font.Image.PixelWidth;
            int destX = 0;
            foreach (var letter in letters)
            {
                for (int sourceY = (int)letter.Y, destY = 0; destY < letter.Height; sourceY++, destY++)
                {
                    Array.Copy(source, (sourceY * sourceWidth) + (int)letter.X, dest, (destY * width) + destX, (int)letter.Width);
                }
                destX += (int)letter.Width;
            }
            return bmp;
        }
        public static Rectangle[] GetElements(string text, string fontName)
        {
            var font = fonts[fontName];
            return (from c in text
                    let r = font.Metrics[c]
                    select new Rectangle
                    {
                        Width = r.Width,
                        Height = r.Height,
                        
                        Fill = new ImageBrush { 
                            ImageSource = font.Image, 
                            AlignmentX=AlignmentX.Left,
                            AlignmentY=AlignmentY.Top,
                            Transform = new TranslateTransform { X = -r.X, Y = -r.Y },
                            Stretch=Stretch.None                        
                        },
                    }).ToArray();
        }
    }
