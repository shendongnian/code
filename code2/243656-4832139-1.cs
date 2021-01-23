    int min = 2;
    int max = 10000;
    Enumerable.Range(min, max - min + 1)
              .AsParallel()
              .ForAll(g =>
                 {
                     bool prime = true;
                     for (int i = 2; i <= Math.Sqrt(g); i++)
                     {
                          if (g % i == 0)
                          {
                             prime = false;
                             break;
                          }
                     }
                     if (prime) Console.WriteLine(g);
                 });
