csharp
var shaped = groups.GroupBy(g => new { g.id, g.groupName})      // GroupBy using both the group's ID and it's name so they're a part of the key
                   .Select(g => new ChildGroup {                // Shape the object into a child group
                        parentId = g.Key.id,                    // Assign the id from the key
                        groupName = g.Key.groupName,            // Assign the groupName from the key
                        childs = g.Select(gc => new Child {     // Iterate over the grouped collection to build the children.
                            id = gc.id,                         // Assign the child's id from the grouped collection.
                            childName = gc.childName            // Assign the child's childName from the grouped collection.
                        }).ToList()                             // Cast to a list to conform to the model.
   		           });
It would also be possible to eliminate one of the selects by using one of the `GroupBy` overload methods:
csharp
 groups.GroupBy(g => new { g.id, g.groupName}, 
               (key, c) => new ChildGroup {
                    parentId = key.id,
                    groupName = key.groupName,
                    childs = c.Select(gc => new Child {
                        id = gc.id,
                        childName = gc.childName
                    }).ToList()
                });
