    public Color ColorBasedOnPercent(decimal percent, params Color[] colors)
        {
            if (colors.Length == 0)
            {
                //I am using Transparent as my default color if nothing was passed
                return Color.Transparent;
            }
            if (percent > 1)
            {
                percent = percent / 100;
            }
            //find the two colors within your list of colors that the percent should fall between
            var colorRangeIndex = (colors.Length - 1) * percent;
            var minColorIndex = (int)Math.Truncate(colorRangeIndex);
            var maxColorIndex = minColorIndex + 1;
            var minColor = colors[minColorIndex];
            if (maxColorIndex < colors.Length)
            {
                var maxColor = colors[maxColorIndex];
                
                //get the differences between all the color values for the two colors you are fading between
                var aScale = maxColor.A - minColor.A;
                var redScale = maxColor.R - minColor.R;
                var greenScale = maxColor.G - minColor.G;
                var blueScale = maxColor.B - minColor.B;
                
                //the decimal distance of how "far" this color should be from the minColor in the range
                var gradientPct = colorRangeIndex - minColorIndex;
                //for each piece of the color (ARGB), add a percentage(gradientPct) of the distance between the two colors
                int getRGB(int originalRGB, int scale) => (int)Math.Round(originalRGB + (scale * gradientPct));
                return Color.FromArgb(getRGB(minColor.A, aScale), getRGB(minColor.R, redScale), getRGB(minColor.G, greenScale), getRGB(minColor.B, blueScale));
            }
            return minColor;
        }
