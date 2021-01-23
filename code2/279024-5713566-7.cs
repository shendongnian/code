    List<Child> children = new List<Child>();
    children.Add(new Child { ID = 1, Name = "Tom" });
    children.Add(new Child { ID = 2, Name = "Dick" });
    children.Add(new Child { ID = 3, Name = "Harry" });
    BaseCollection bases = BaseCollection.ToBase(children);
    bases.Print();
    List<Child> children2 = BaseCollection.FromBase<Child>(bases);
    BaseCollection.Print(children2);
