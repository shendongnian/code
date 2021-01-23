    var list = new List<Subject>
    {
        new Subject {Id = 0, ParentId = null, Name = "A"},
        new Subject {Id = 1, ParentId = 0, Name = "B"},
        new Subject {Id = 2, ParentId = 1, Name = "C"},
        new Subject {Id = 3, ParentId = 1, Name = "D"},
        new Subject {Id = 4, ParentId = 2, Name = "E"},
        new Subject {Id = 5, ParentId = 3, Name = "F"},
        new Subject {Id = 6, ParentId = 0, Name = "G"},
        new Subject {Id = 7, ParentId = 4, Name = "H"},
        new Subject {Id = 8, ParentId = 3, Name = "I"},
    };
    var rootNode = Node<Subject>.CreateTree(list, n => n.Id, n => n.ParentId).Single();
    foreach (var node in rootNode.All)
    {
        Console.WriteLine("Name {0} , Level {1}", node.Value.Name, node.Level);
    }
