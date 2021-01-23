        public static double GetHue(int rgb)
        {
            double result = 0.0;
            int r = rgb & 0xFF;
            int g = (rgb >> 8) & 0xFF;
            int b = (rgb >> 16) & 0xFF;
            if (r != g && g != b)
            {
                double red = r / 255.0;
                double green = g / 255.0;
                double blue = b / 255.0;
                double max = Math.Max(Math.Max(red, green), blue);
                double min = Math.Min(Math.Min(red, green), blue);
                double delta = max - min;
                if (delta != 0)
                {
                    if (red == max)
                        result = (green - blue) / delta;
                    else if (green == max)
                        result = 2 + ((blue - red) / delta);
                    else if (blue == max)
                        result = 4 + ((red - green) / delta);
                    result *= 60.0f;
                    if (result < 0f)
                        result += 360.0f;
                }
            }
            return result;
        }
