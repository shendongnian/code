    public static IEnumerable<T> Where<T>(this IEnumerable<T> sequence, 
                                          string[] criteria){
    var properties = typeof(T).GetProperties()
                              .Where(p=>p.GetGetMethod() != null);
    return from s in sequence
           let text = properties.Aggregate("",(acc,prop) => 
                                                   acc + 
                                                   "\t" + 
                                                   prop.GetValue(s,null)
                                           )
           where criteria.All(c => text.Contains(c))
           select s;
    }
