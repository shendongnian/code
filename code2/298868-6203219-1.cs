     for (int I = 0; I < 10; I++) {
          for (int A = 0; A < 10; A++) {
               for (int B = 0; B < 10; B++) {
                   if (something)
                       goto endOfTheLine;
                }
          }
      }
      endOfTheLine:
      Console.WriteLine("Pure evilness executed");
