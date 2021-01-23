 lang-cs
    var list = new List<Car>();
    list.AddRange(GetGreenCars()?.Except(list) ?? new List<Car>());
    list.AddRange(GetBigCars()?.Except(list) ?? new List<Car>());
    list.AddRange(GetSmallCars()?.Except(list) ?? new List<Car>());
