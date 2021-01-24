lang-cs
ObjectBList.RemoveAll(p => ObjectAList.Find(p2 => p2.Item == p.Item) != null ? true : false);
Full Example:
lang-cs
public class ObjectBase {
    public string Item;
    public int b;
}
public class ObjectA : ObjectBase{ }
public class ObjectB : ObjectBase { }
public List<ObjectB> Testing() {
    var list1 = new List<ObjectA> { new ObjectA { Item = "str1", b = 0 } };
    var list2 = new List<ObjectB> { new ObjectB { Item = "str1", b = 0 }, new ObjectB { Item = "str2", b = 1 } };
    // Key Line - Remove all from list2 found in list1
    list2.RemoveAll(p => list1.Find(p2 => p2.Item == p.Item) != null ? true : false);
    return list2;
}
        
