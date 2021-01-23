    ulong min = 0;
    ulong max = 100000;
    ulong i = 0;
    ulong sqrt = 0;
    ulong j = 0;
    
    bool prime = true;
    for (i = min; i <= max; i += 2)
    {
      prime = true;
      sqrt = Math.Sqrt(i) + 1;
      if (i % 2 == 0) prime = false;
      else for (j = 3; j < sqrt; j += 2)
      {
        if (i % j == 0)
        {
          prime = false;
          break;
        }
      }
      if(prime)
      {
        Console.WriteLine(i);
      }
    }
