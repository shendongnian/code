      using System.Linq; 
      using System.Reflection;
      ...
      // Key   : type + field name, say Tuple.Create(typeof(Thing1), "Name")
      // Value : corresponding value, say "Thing 1";
      static Dictionary<Tuple<Type, string>, string> s_Dictionary = AppDomain
        .CurrentDomain
        .GetAssemblies() // I've taken all assemblies; you may want to add Where here
        .SelectMany(asm => asm.GetTypes())
        .Where(t => t.IsAbstract && t.IsSealed) // All static types, you may want to add Where
        .SelectMany(t => t
           .GetFields()                         // All constant string fields
           .Where(f => f.FieldType == typeof(string))
           .Where(f => f.IsPublic && f.IsStatic)
           .Where(f => f.IsLiteral && !f.IsInitOnly) // constants only
           .Select(f => new { 
             key = Tuple.Create(t, f.Name),
             value = f.GetValue(null)
           }))
        .ToDictionary(item => item.key, item => item.value?.ToString());
