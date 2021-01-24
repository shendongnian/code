    var DicB = ListB.ToDictionary(x => x.C1C2, x => x);
    
    foreach(var itemA in ListA)
    {
        if(DicB.ContainsKey(itemA.C1C2))
        {
            var itemB = DicB[itemA.C1C2];
            itemB.Desc1 = itemA.Desc1;
            itemB.Desc2 = itemA.Desc2;
            itemB.DataType = itemA.DataType;
        }
    }
