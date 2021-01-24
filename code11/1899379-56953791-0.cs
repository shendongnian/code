    // use only one instance of System.Random to avoid getting duplicates
      static System.Random ra = new Random();
      static double GenRnadNum(int min,int max,double step)
            {
               //  calc the max-min and round down
                int n = (int)((max - min) / step);
                int r=  ra.Next(0, n);
                return min + r * step;
            }
