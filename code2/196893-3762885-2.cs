    foreach (var item in type.GetProperties(
       BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
          .Where(pi=>pi.GetGetMethod().IsHideBySig || pi.ReflectedType.BaseType == typeof(Object))
    {
            Console.WriteLine("{0} {1}", type.Name, item.Name);
    }
