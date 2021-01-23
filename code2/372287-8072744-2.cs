      Dictionary<Type, Type> mappings = new Dictionary<Type,Type>();
       foreach (Type t in MyServiceAssembly.GetTypes())
      {
        if (t.GetInterfaces().Length > 0)
        {
          foreach (Type ti in t.GetInterfaces())
            
            {
              if (mapping.ContainsKey(ti))
                System.Diagnostics.Debug.WriteLine("Class {0} implements more than one interface {1}", t.FullName, ti.FullName);
              else
                mapping.Add(ti, t);
              // System.Diagnostics.Debug.WriteLine("Class {0} implements {1}", t.FullName, ti.FullName);
            }
        }
      }
