    public static void AddUnique<T>( this IList<T> self, IEnumerable<T> items )
    {
        foreach(var item in items)
            if(!self.Contains(item))
                self.Add(item)
    }
    var list = new List<Car>();
    list.AddUnique(GetGreenCars());
    list.AddUnique(GetBigCars());
    list.AddUnique(GetSmallCars());
