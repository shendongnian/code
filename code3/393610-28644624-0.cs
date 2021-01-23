    public static void AddUnique<T>(this IList<T> self, IEnumerable<T> items)
    {
      self.AddRange(
        items.Where(x => self.Where(y => y.Name == x.Name).Count() <=
        0).ToList());
    }
    var list = new List<Car>();
    list.AddUnique(GetGreenCars());
    list.AddUnique(GetBigCars());
    list.AddUnique(GetSmallCars());
