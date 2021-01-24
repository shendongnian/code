    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    static class Util {
        public static Color[][] ExtractColorArrayFrom(Bitmap bm)
        {
            int height = bm.Height;
            int width = bm.Width;
            var toret = new Color[height][];
            
            for(int i = 0; i < height; ++i) {
                toret[ i ] = new Color[ width ];
                
                for(int j = 0; j < width; ++j) {
                    toret[ i ][ j ] = bm.GetPixel( i, j );
                }
            }
            
            return toret;
        }
        
        public static int[] ARGBFrom(Color c)
        {
            return new int[]{ c.A, c.R, c.G, c.B };
        }
    }
