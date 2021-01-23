    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> myList)
    {
        var oc = new ObservableCollection<T>();
        foreach (var item in myList)
            oc.Add(item);
        return oc;
    }
