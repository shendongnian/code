    var winners = new HashSet<int>();
    while(winners.Count < 10)
    {
      var number = random.Next(100);
      if(!winners.Contains(number)) winners.Add(number);
    }
    
    for(i = 0; i < 100; i++)
    {
      if(winners.Contains(i)) Console.WriteLine("{0} won!!!", i);
      else Console.WriteLine("{0} didn't win, sorry...", i);
    }
