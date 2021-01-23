        using System;
        public class GenerateRandom
        {
        	private int max;
            private int last;
            static void Main(string[] args)
            {
              GenerateRandom rand = new GenerateRandom(10);
        		 for (int i = 0; i < 25; i++)
        		 {
        			 Console.WriteLine(rand.nextInt());
        		 }
            }
        	// constructor that takes the max int
        public GenerateRandom(int max)
        {
            this.max = max;
        	DateTime dt = DateTime.Now;//getting current DataTime
        	int ms = dt.Millisecond;//getting date in millisecond
            last = (int) (ms % max);
        }
        
        // Note that the result can not be bigger then 32749
        public int nextInt()
        {
            last = (last * 32719 + 3) % 32749;//this value is set as per our requirement(i.e, these is not a static value
            return last % max;
        }
        }
     
