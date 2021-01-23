    public static class Extenders
    {
        public static void FindByTempID(this ObservableCollection<IObjectWithTempID> e, long tempID)
        {
        }
        public static void FindByTempID2(this IEnumerable<IObjectWithTempID> e, long tempID)
        {
        }
        public static void FindByTempID3(this ObservableCollection<TestObjectWithTempID> e, long tempID)
        {
        }
        public static void FindByTempID4<T>(this ObservableCollection<T> e, long tempID)
        {
        }
    }
