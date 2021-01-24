`c#
        private static Image GetNewImage(string path)
        {
            Bitmap original = new Bitmap(path);
            Bitmap result = new Bitmap(original.Width, original.Height);
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    var px = original.GetPixel(x, y);
                    result.SetPixel(x, y, Color.FromArgb((int)GetColorLuminance(px), px.R, px.G, px.B));
                }
            }
            return result;
        }
        private static float GetColorLuminance(Color color)
        {
            var R = color.R * .2125f;
            var G = color.G * .7154f;
            var B = color.B * .0721f;
            return R + G + B;
        }
`
