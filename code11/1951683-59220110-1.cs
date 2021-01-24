    public class DataTableExt {
        public static IEnumerable<T> ToIEnumerable<T>(this DataTable dt) where T : new() {
            var props = typeof(T).GetPropertiesOrFields()
                                 .Where(mi => dt.Columns.Contains(mi.Name) && mi.GetCanWrite())
                                 .ToList();
            foreach (var row in dt.AsEnumerable()) {
                var aT = new T();
                foreach (var p in props)
                    p.SetValue(aT, row[p.Name]);
                yield return aT;
            }
        }
    }
