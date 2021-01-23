    static int binaryadd(int x, int y)
            {
                while (x != 0)
                {
                    int c = y & x;
                    y = y ^ x; 
                   x = c << 1;
                    
                }
                return y;
        }
