    public class MyCollectionView : CollectionView
    {
        public MyCollectionView(IEnumerable collection)
            : base(collection)
        {
            base.SetCurrent(xxx, yyy);
        }
    }
