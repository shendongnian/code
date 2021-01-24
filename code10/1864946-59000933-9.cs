    public static class CollectionViewExtensions {
        public static bool IsCurrentFirst(this ICollectionView view) {
            return view.CurrentItem != null && view.CurrentPosition == 0;
        }
        public static bool IsCurrentLast(this ICollectionView view) {
            if (view.CurrentItem == null) return false;
            var index = view.CurrentPosition;
            var max = view.Count() - 1;
            return index == max;
        }
        static int Count(this ICollectionView source) {
            int count = 0;
            var e = source.GetEnumerator();
            checked {
                while (e.MoveNext()) count++;
            }            
            return count;
        }
    }
