    public static class CollectionViewExtensions {
        public static bool IsCurrentFirst(this ICollectionView view) {
            return view.CurrentItem != null && view.CurrentPosition == 1;
        }
        public static bool IsCurrentLast(this ICollectionView view) {
            if (view.CurrentItem == null) return false;
            var position = view.CurrentPosition;
            var count = view.Cast<object>().Count();
            return position == count;
        }
    }
