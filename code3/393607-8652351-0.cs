    var list = new List<Car>();
    list.AddRange(GetGreenCars());
    list.AddRange(GetBigCars());
    list.AddRange(GetSmallCars());
    list = list.Distinct().ToList();
