    public Tuple<T, int> GetMostCommonProperty<T>(IEnumerable<Pet> pets,
                                                  Func<Pet, T> getData)
    {
        var petGroups = from p in pets
                        let data = getData(p)
                        where data != null
                        group p by new { Data = data, p.PetId } into gp
                        select new { Data = gp.Key.Data, Count = gp.Count() };
        var element = petGroups.OrderByDescending(s => s.Count).First();
        return Tuple.Create(element.Data, element.Count);
    }
