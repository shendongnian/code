    public static void DisposeAll(this IEnumerable set) {
        foreach (Object obj in set) {
            IDisposable disp = obj as IDisposable;
            if (disp != null) { disp.Dispose(); }
        }
    }
