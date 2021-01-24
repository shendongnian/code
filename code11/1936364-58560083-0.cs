    namespace ConsoleApp2
    {
        internal static class Program
        {
            private static void Main(string[] args)
            {
                // generate 2D array sample
    
                const int w = 3;
                const int h = 5;
    
                var i = 0;
    
                var source = new int[w, h];
    
                for (var y = 0; y < h; y++)
                for (var x = 0; x < w; x++)
                    source[x, y] = i++;
    
                // convert to 1D array
    
                var j = 0;
    
                var target = new int[w * h];
    
                for (var y = 0; y < h; y++)
                for (var x = 0; x < w; x++)
                    target[j++] = source[x, y];
    
                // convert back to 2D array
    
                var result = new int[w, h];
    
                for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                    result[x, y] = target[y * w + x];
            }
        }
    }
