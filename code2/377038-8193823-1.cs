    public static IEnumerable<T> Reverse<T>(this LinkedList<T> list) {
        var el = list.Last;
        while (el != null) {
            yield return el.Value;
            el = el.Previous;
        }
    }
