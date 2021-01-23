 lang-cs
    var list = new List<Car>();
    list.AddRange(GetGreenCars()?.Except(list));
    list.AddRange(GetBigCars()?.Except(list));
    list.AddRange(GetSmallCars()?.Except(list));
