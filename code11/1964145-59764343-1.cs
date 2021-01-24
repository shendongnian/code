csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
public static List<Type> AllAccessiableEnums()
{
    var entry = Assembly.GetEntryAssembly();
    var referenced = entry
        .GetReferencedAssemblies()
        .Select(t => Assembly.Load(t))
        .ToList();
    
    referenced.Add(entry);
    return referenced
        .SelectMany(t => t.GetTypes())
        .Where(t => t.IsEnum) // Use your own filter here.
        .ToList();
}
**Caution:** Calling this may get lots of enums from Microsoft.
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/DxJhn.png
