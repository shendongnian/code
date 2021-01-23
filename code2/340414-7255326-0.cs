    public static class Tracking
    {
        private static class ListHelper<T>
        {
            internal static List<TrackList<T>> Lists = new List<TrackList<T>>();
        }
        private static class DictionaryHelper<K, V>
        {
            internal static List<TrackedDictionary<K,V>> Dictionaries =
                new List<TrackedDictionary<K,V>>()
        }
    
        public static void Register<K,V>(TrackedDictionary<K,V> dictionary)
        {
            DictionaryHelper<K, V>.Dictionaries.Add(dictionary);
        }
    
        public static void Register<T> (TrackList<T> list)
        {
            ListHelper<T>.Lists.Add(list);
        }
    }
