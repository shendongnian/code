    public void DoSomething(){
      Stopwatch stopWatch = new Stopwatch();
      stopWatch.Start();
    
      //stuff you want to time
    
      stopWatch.Stop();
    
      System.Console.Writeln(String.Format("Total Ticks: {0}", stopWatch.ElapsedTicks))
    }
