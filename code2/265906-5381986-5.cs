    private static void recurseAndPrintProperties(Object ObjectToRecurse) {
       foreach (PropertyInfo pi in ObjectToRecurse.GetType().GetProperties()) {
           if ((pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>))) {
               IEnumerable collection = (IEnumerable)pi.GetValue(ObjectToRecurse, null);
    
               foreach (object val in collection)
                   recurseAndPrintProperties(val);
           } else {
                if (pi.PropertyType == typeof(Descendant)) {
                    Descendant actualDescendant = (Descendant)pi.GetValue(ObjectToRecurse, null);
                    Console.WriteLine(actualDescendant.idDescendant + " - " + actualDescendant.Name);
                } else
                    Console.WriteLine(pi.Name + "  -  " + pi.GetValue(ObjectToRecurse, null));
           }
       }
    }
