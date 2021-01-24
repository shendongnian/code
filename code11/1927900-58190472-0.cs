    void Main()
    {
       double x = 1.0;
       double res = 33
       for (int i=0; i<=10; i++)
       {
            res = calc(res, x);
            Console.WriteLine(res);
        }
    }
    
     static double calc(double val, double roc)
     {
          double c = 0;
    
          c = val + roc;
    
          return c;             
      }
