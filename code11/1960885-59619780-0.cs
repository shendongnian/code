     private object GetKidsOfBaseClass(string baseClass)
        {
            Type baseType = Type.GetType($"{baseClass}");
            var blahKids = AppDomain.CurrentDomain.GetAssemblies().SelectMany(ass => ass.GetTypes())
                .Where(p => p.IsSubclassOf(baseType));
            var kids = Assembly.GetAssembly(baseType).GetTypes().Where(t => t.IsSubclassOf(baseType));
            return kids;
        }
