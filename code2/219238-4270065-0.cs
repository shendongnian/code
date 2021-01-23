    public void Numbers(int iteration, int number, int limit)
    {
      if(iteration < limit) {
        Console.WriteLine(number);
        Numbers(iteration + 1, number + iteration);
      }
    }
    
    Numbers(0,1,5);
