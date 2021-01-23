    public void TestOfT<T>(List<T> pList) where T:class, new() {
        var xt = Activator.CreateInstance(typeof(T));
        foreach (var tp in pList[0].GetType().GetProperties()) {
            Debug.WriteLine(tp.Name);
            Debug.WriteLine(tp.PropertyType);
            Debug.WriteLine(tp.GetType().Name);
            Debug.WriteLine(tp.GetValue(pList[0], null));
        }
     }
