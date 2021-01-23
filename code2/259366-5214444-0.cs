    class MyRand  // Assuming MyRand is the class name
    {
       private Random r = new Random();
       public int GetRand(int min, int max)
       {
           return r.Next(min, max);
       }
    }
