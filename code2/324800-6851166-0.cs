    var gridOneFirstHalf = new Row[][] { GridOne.Rows.Take(GridOne.Rows.Count / 2), new Row[GridOne.Rows.Count / 2] };
    var gridOneSecondHalf = new Row[][] { GridOne.Rows.Skip(GridOne.Rows.Count / 2).ToArray(), new Row[GridOne.Rows.Count / 2] };
    
    ParameterizedThreadStart halfThreadStarter = new ParameterizedThreadState((state) => ProcessIntoResultsMember(state));
    
    Thread processFirstHalf = new Thread(halfThreadStarter, gridOneFirstHalf);
    Thread processSecondHalf = new Thread(halfThreadStarter, gridOneSecondHalf);
    
    processFirstHalf.Start();
    processSecondHalf.Start();
    
    processFirstHalf.Join();
    processSecondHalf.Join();
    
    GridTwo.Rows = gridOneFirstHalf[1].Concat(gridOneSecondHalf[1]);
