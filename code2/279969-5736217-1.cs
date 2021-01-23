    public static class ColorExtensions
    {
        /// <summary>
        /// Gets the luminance of the color. A value between 0 (black) and 1 (white)
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="algorithm">The type of luminance alg to use.</param>
        /// <returns>A value between 0 (black) and 1 (white)</returns>
        public static double GetLuminance(this Color color, LuminanceAlgorithm algorithm = LuminanceAlgorithm.Photometric)
        {
            switch (algorithm)
            {
                case LuminanceAlgorithm.CCIR601:
                    return (0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B) / 255;
                case LuminanceAlgorithm.Perceived:
                    return (Math.Sqrt(0.241 * Math.Pow(color.R, 2) + 0.691 * Math.Pow(color.G, 2) + 0.068 * Math.Pow(color.B, 2)) / 255);
                case LuminanceAlgorithm.Photometric:
                    return (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            }
            
        }
       /// <summary>
       /// The luminances
       /// </summary>
       public enum LuminanceAlgorithm
       {
           /// <summary>
           /// Photometric/digital ITU-R
           /// </summary>
           Photometric,
           /// <summary>
           /// Digital CCIR601 (gives more weight to the R and B components, as preciev by the human eye)
           /// </summary>
           CCIR601,
           /// <summary>
           /// A perceived luminance
           /// </summary>
           Perceived
       }
    }
