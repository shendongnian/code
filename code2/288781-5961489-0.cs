    Assembly asm = ...
    var propertiesByTag =
        from t in asm.GetTypes()
        from p in t.GetProperties()
        from a in p.GetCustomAttributes(typeof(TagAttribute)).Cast<TagAttribute>()
        group p by a.Tag into g
        select new
        {
            Tag = g.Key,
            Properties = g.ToArray()
        }
    
        foreach (var dup in propertiesByTag.Where(x => x.Properties.Length > 1))
        {
            Console.WriteLine("Duplicated tag: {0}", dup.Tag);
            foreach(var p in dup.Properties)
                Console.WriteLine("\t{0}.{1}", p.DeclaringType.Name, p.Name);
        }
