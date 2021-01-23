    public void fun()
    {
          int Choice=0;
          try 
          {
              Choice = int.Parse(Console.ReadLine()); 
          } 
          catch (Exception) 
          {
              fun(); 
          }
    }
