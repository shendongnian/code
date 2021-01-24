            public static IList<T> ToInterfacedObjects<T>(this IEnumerable<T> data) where T : class
            {
                var list = new List<T>();
                foreach (var datum in data)
                {
                    var myType = MakeDynamicType<T>();
                    foreach (var pi in typeof(T).GetProperties())
                    {
                        var val = pi.GetValue(datum);
                        pi.SetValue(myType, val);
                        list.Add(myType);
                    }
                }
                return list;
            }
 
