    var myDict = new Dictionary<int, PointIt>();
    
    var p1 = new PointIt() { PositionX=1, PositionY=2, 	ElectricalPotential=999.99};
    var p2 = new PointIt() { PositionX=1, PositionY=2, 	ElectricalPotential=999.99};
    
    myDict.Add(p1.GetHashCode(), p1);
    myDict.Add(p2.GetHashCode(), p2);
    
    myDict.ToList()
          .ForEach(itm => Console.WriteLine($"Key ({itm.Key}) Value {itm.Value}"));
