public List<Obj1> GetObj1List(int id)
{
    var obj1List = Select(x => x.ObjTable.Where(a => a.Id == id))
        .Select(MapObject2ToObject1)
        .ToList();
    return obj1List;
}
