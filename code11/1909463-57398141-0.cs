    foreach (var item in result)
    {
        if(item.PositionStartDate == null)
        {
            item.PositionDateStart = DateTime.Now;
        }
        Console.WriteLine(item.PositionDateStart.GetType());
    }
