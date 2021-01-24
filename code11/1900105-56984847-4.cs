      using System.Linq;
      ...
      var props = item
        .GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(pi => pi.CanRead)                      // can be read
        .Where(pi => !pi.GetIndexParameters().Any())  // not an indexer
        .Select(pi => new {
          name = pi.Name,
          value = pi.GetValue(pi.GetGetMethod().IsStatic ? null : item),
          type = pi.PropertyType,
          kind = "property",                          
        });
