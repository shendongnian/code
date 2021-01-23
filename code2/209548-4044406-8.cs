    using System.Drawing;
    
    static class Extensions
    {
        /// <summary>
        /// Converts an integer value in twips to the corresponding integer value
        /// in pixels on the x-axis.
        /// </summary>
        /// <param name="source">The Graphics context to use</param>
        /// <param name="inTwips">The number of twips to be converted</param>
        /// <returns>The number of pixels in that many twips</returns>
        public static int ConvertTwipsToXPixels(this Graphics source, int twips)
        {
            return (int)(((double)twips) * (1.0 / 1440.0) * source.DpiX);
        }
        /// <summary>
        /// Converts an integer value in twips to the corresponding integer value
        /// in pixels on the y-axis.
        /// </summary>
        /// <param name="source">The Graphics context to use</param>
        /// <param name="inTwips">The number of twips to be converted</param>
        /// <returns>The number of pixels in that many twips</returns>
        public static int ConvertTwipsToYPixels(this Graphics source, int twips)
        {
            return (int)(((double)twips) * (1.0 / 1440.0) * source.DpiY);
        }
    }
