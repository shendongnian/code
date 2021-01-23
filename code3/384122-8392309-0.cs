    public void CountNumber() 
    {
       foreach(int i = 0; i < 40; i++) {
          if(i > 20) {
             continue; // Skips the rest of this loop iteration
          }
          Console.WriteLine("hello " + 1);
       }
    }
