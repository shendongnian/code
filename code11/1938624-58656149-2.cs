public List<Obj1> GetObj1List(int id)
{
    var obj1List = Select(x => x.ObjTable.Where(a => a.Id == id))
        .Select(o => MapObject2ToObject1(o, OtherMethod))
        .ToList();
    return obj1List;
}
_Updated with updated method signature for `MapObject2ToObject1`_
