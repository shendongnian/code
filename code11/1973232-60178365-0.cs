csharp
var shaped = groups.GroupBy(g => new { g.id, g.groupName})
                   .Select(g => new ChildGroup {
                        parentId = g.Key.id,
                        groupName = g.Key.groupName,
                        childs = g.Select(gc => new Child {
                            id = gc.id,
                            childName = gc.childName
                        }).ToList()
   		           });
 
