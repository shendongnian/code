    public class TableParser
    {
        private static bool Store(List<string> lst, string cell) { lst.Append(cell); return true; }
        private static bool Store(List<int> lst, string cell) { int val; if (!int.TryParse(cell, out val)) return false; lst.Append(val); return true; }
        private static bool Store(List<double> lst, string cell) { double val; if (!double.TryParse(cell, out val)) return false; lst.Append(val); return true; }
        private static readonly Dictionary<Type, System.Reflection.MethodInfo> storeMap = new Dictionary<Type, System.Reflection.MethodInfo>();
        static TableParser()
        {
            System.Reflection.MethodInfo[] storeMethods = typeof(TableParser).GetMethods("Store", BindingFlags.Private | BindingFlags.Static);
            foreach (System.Reflection.MethodInfo mi in storeMethods)
                storeMap[mi.GetParameters()[0].GetGenericParameters()[0]] = mi;
        }
        private readonly List< Predicate<string> > columnHandlers = new List< Predicate<string> >;
        public bool TryBindColumn<T>(List<T> lst)
        {
            System.Reflection.MethodInfo storeImpl;
            if (!storeMap.TryGetValue(typeof(T), out storeImpl)) return false;
            columnHandlers.Add(Delegate.Create(typeof(Predicate<string>), storeImpl, lst));
            return true;
        }
        // adapt your existing logic to grab a row, pull it apart with string.Split or whatever, and walk through columnHandlers passing in each of the pieces
    }
