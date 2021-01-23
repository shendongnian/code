    IList<Tuple<Data,Data> > UpdateList = List_new.Where(
    delegate(Data item)
    {
    return List_old.Any(y => item.name == y.name && item.Version > y.Version) ||
    !List_old.Any(y => item.name == y.name);
    }
    ).Select(
    delegate(Data item)
    {
    Data old_item = List_old.FirstOrDefault(y => item.name == y.name && item.Version > y.Version);
    return new Tuple<Data,Data>(item, old_item);
    }
    ).ToList();
