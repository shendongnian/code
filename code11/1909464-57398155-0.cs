    //Point at which code errors outs 
    foreach (var item in result)
    {
       if (item.PositionDateStart == null)
           item.PositionDateStart = DateTime.Now;
       Console.WriteLine(item.PositionDateStart);
       Console.WriteLine(item.PositionDateStart.GetType());
    }
