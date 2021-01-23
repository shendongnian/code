    public class NonGenericClass
    {
        public void Print<T>(IEnumerable<T?> vals) where T : struct
        {
            PrintRestricted(vals.Where(v =>  v.HasValue));
        }
    
        public void Print<U>(IEnumerable<T> vals) where T : class
        {
            PrintRestricted(vals.Where(v => v != default(T)));
        }
    
        private void PrintRestricted<U>(IEnumerable<T> vals)
        {
            foreach (var v in vals)
            {
                Trace.WriteLine(v.ToString());
            }
            Trace.WriteLine(string.Empty);
        }
    }
