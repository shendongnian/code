    public static class CollectionViewExtensions {
        public static bool IsCurrentFirst(this ICollectionView view) {
            return view.CurrentItem != null && view.CurrentPosition == 0;
        }
        public static bool IsCurrentLast(this ICollectionView view) {
            if (view.CurrentItem == null) return false;
            var index = view.CurrentPosition;
            var max = view.Cast<object>().Count() - 1;
            return index == max;
        }
    }
