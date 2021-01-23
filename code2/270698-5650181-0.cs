    public class EntityCollectionObserver<T> : ObservableCollection<T> where T : class
    {
        private static List<Tuple<IBindingList, EntityCollection<T>, EntityCollectionObserver<T>>> InnerLists 
            = new List<Tuple<IBindingList, EntityCollection<T>, EntityCollectionObserver<T>>>();
        public EntityCollectionObserver(EntityCollection<T> entityCollection)
            : base(entityCollection)
        {
            IBindingList l = ((IBindingList)((IListSource)entityCollection).GetList());
            l.ListChanged += new ListChangedEventHandler(OnInnerListChanged);
            foreach (var x in InnerLists.Where(x => x.Item2 == entityCollection && x.Item1 != l))
            {
                x.Item3.ObserveThisListAswell(x.Item1);
            }
            InnerLists.Add(new Tuple<IBindingList, EntityCollection<T>, EntityCollectionObserver<T>>(l, entityCollection, this));
        }
        private void ObserveThisListAswell(IBindingList l)
        {
            l.ListChanged += new ListChangedEventHandler(OnInnerListChanged);
        }
        private void OnInnerListChanged(object sender, ListChangedEventArgs e)
        {
            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
