    using System.Linq;
    ...
    bool contains = list.Contains(
      new Entity.Limit(1, 2),
      new EntityEqualityComparer());
