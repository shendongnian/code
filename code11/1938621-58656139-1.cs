    public List<Obj1> GetObj1List(int id) =>
        Select(x => x.ObjTable.Where(a => a.Id == id)
        .AsEnumerable()
        .Select(MapObject2ToObject1)
        .ToList();
