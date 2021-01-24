    internal static void DefaultShow(object o) {
        if ( o is IEnumerable) {
            Console.WriteLine(string.Join("|", (o as IEnumerable).Cast<object>().Select(x => x.ToString())));
        } else {
            Console.WriteLine(o.ToString());
        }
    }
