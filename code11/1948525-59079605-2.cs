    public class EnumerableComparer : IComparer<IEnumerable<object>> {
        public int Compare(IEnumerable<object> xs, IEnumerable<object> ys) {
            var xe = xs.GetEnumerator();
            var ye = ys.GetEnumerator();
    
            var sofar = 0;
            while (sofar == 0 && xe.MoveNext()) {
                if (!ye.MoveNext())
                    sofar = 1;
                else {
                    var ct = typeof(Comparer<>).MakeGenericType(xe.Current.GetType());
                    var c = ct.GetProperty("Default").GetValue(null);
                    var fc = ct.GetMethod("Compare");
                    sofar = (int)fc.Invoke(c, new[] { xe.Current, ye.Current });
                }
            }
            if (sofar == 0 && ye.MoveNext())
                sofar = -1;
    
            return sofar;
        }
    }
