     public static IEnumerable<T> Where<T>(this IEnumerable<T> sequence, string[] criteria){
                var properties = typeof(T).GetProperties().Where(p=>p.GetGetMethod() != null);
                return from p in sequence
                       let text = properties.Aggregate("",(acc,p) => acc + "\t" + p.GetValue(p,null)
                       where criteria.All(s=>text.Contains(s))
                       select p;
    }
