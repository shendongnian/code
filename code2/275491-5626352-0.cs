    var changeList = new List<Integer>
    for(i = 0; i < yourList.Count() - 1; i++)
    {
        changeList.Add(yourList.Item(i + 1) - yourList.Item(i));
    }
    
    //Determine if the nature of the list
    
    var positiveChangeCount = changeList.Where(x => x < 0);
    var negativeChangeCount = changeList.Where(x => X > 0);
    
    if (positiveChangeCount = yourList.Count)
    {
       Accreting;
    }
    elseif (negativeChangeCount = yourList.Count)
    {
       Amortizing;
    }
    elseif (negativeChangeCount + PositiveChangeCount = 0)
    {
      Bullet;
    }
    else
    {
      Rollercoaster;
    }
