    public abstract class CollectionSyncronizer<T1, T2>
    {
        public bool IsSyncronized { get; protected set; }               
        public abstract void Syncronize();
        protected void Update<TColl, TSource, TTarget>(TColl targetCollectionToBeUpdated, NotifyCollectionChangedEventArgs e, Dictionary<TSource, TTarget> mapFromSourceToTarget, Func<TSource, TTarget> targetItemsGenerator) where TColl : IList<TTarget>
        {            
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (TSource sourceItem in e.NewItems)
                        {
                            var targetItem = targetItemsGenerator(sourceItem);
                            mapFromSourceToTarget.Add(sourceItem, targetItem);
                            targetCollectionToBeUpdated.Add(targetItem);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (TSource removedSourceItem in e.OldItems)
                        {
                            targetCollectionToBeUpdated.Remove(mapFromSourceToTarget[removedSourceItem]);
                            mapFromSourceToTarget.Remove(removedSourceItem);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    {
                        int i = 0;
                        foreach (TSource newSourceItem in e.NewItems)
                        {
                            var newTargetItem = targetItemsGenerator(newSourceItem);
                            mapFromSourceToTarget.Add(newSourceItem, newTargetItem);
                            targetCollectionToBeUpdated[e.NewStartingIndex + i] = newTargetItem;
                            i += 1;
                        }
                        foreach (TSource oldSourceItem in e.OldItems)
                        {
                            mapFromSourceToTarget.Remove(oldSourceItem);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    {
                        targetCollectionToBeUpdated.RemoveAt(e.OldStartingIndex);
                        targetCollectionToBeUpdated.Insert(e.NewStartingIndex, mapFromSourceToTarget[(TSource)e.NewItems[0]]);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    {
                        targetCollectionToBeUpdated.Clear();
                    }
                    break;
            }            
        }
    }
    public class OneWayCollectionSyncronizer<TSourceColl, TTargColl, TSource, TTarg> : CollectionSyncronizer<TSource, TTarg> where TSourceColl : INotifyCollectionChanged where TTargColl : IList<TTarg>
    {        
        private readonly Dictionary<TSource, TTarg> _mapFromSourceToTarget = new Dictionary<TSource, TTarg>();        
        private readonly Func<TSource, TTarg> _newTargetItemFromSource;        
        public OneWayCollectionSyncronizer(TSourceColl sourceCollection, TTargColl targetCollection, Func<TSource, TTarg> newTargetItemFromSource)
        {
            SourceCollection = sourceCollection;
            TargetCollection = targetCollection;            
            _newTargetItemFromSource = newTargetItemFromSource;
        }
        public EventHandler TargetCollectionHasBeenUpdated;
        public TSourceColl SourceCollection { get; }
        public TTargColl TargetCollection { get; }        
        public override void Syncronize()
        {
            if (!IsSyncronized)
            {
                SourceCollection.CollectionChanged += UpdateTarget;
                IsSyncronized = true;
            }            
        }
        private void UpdateTarget(object sender, NotifyCollectionChangedEventArgs e)
        {
            Update(TargetCollection, e, _mapFromSourceToTarget, _newTargetItemFromSource);
            TargetCollectionHasBeenUpdated?.Invoke(this, EventArgs.Empty);
        }        
    }
    public class TwoWayCollectionSyncronizer<TColl1, TColl2, T1, T2> : CollectionSyncronizer<T1, T2> where TColl1 : INotifyCollectionChanged, IList<T1> where TColl2 : INotifyCollectionChanged, IList<T2>
    {
        private readonly Dictionary<T1, T2> _mapFromFirstToSecond = new Dictionary<T1, T2>();
        private readonly Dictionary<T2, T1> _mapFromSecondToFirst = new Dictionary<T2, T1>();
        private readonly Func<T1, T2> _newSecondItemFromFirst;
        private readonly Func<T2, T1> _newFirstItemFromSecond;
        public TwoWayCollectionSyncronizer(TColl1 firstCollection, TColl2 secondCollection, Func<T1, T2> newSecondItemFromFirst, Func<T2, T1> newFirstItemFromSecond)
        {
            FirstCollection = firstCollection;
            SecondCollection = secondCollection;
            _newFirstItemFromSecond = newFirstItemFromSecond;
            _newSecondItemFromFirst = newSecondItemFromFirst;
        }
        public EventHandler FirstCollectionHasBeenUpdated;
        public EventHandler SecondCollectionHasBeenUpdated;
        public TColl1 FirstCollection { get; }
        public TColl2 SecondCollection { get; }        
        public override void Syncronize()
        {
            if (!IsSyncronized)
            {
                SecondCollection.CollectionChanged += UpdateFirst;
                FirstCollection.CollectionChanged += UpdateSecond;
                IsSyncronized = true;
            }            
        }
        private void UpdateFirst(object sender, NotifyCollectionChangedEventArgs e)
        {
            FirstCollection.CollectionChanged -= UpdateSecond;
            Update(FirstCollection, e, _mapFromSecondToFirst, _newFirstItemFromSecond);
            FirstCollectionHasBeenUpdated?.Invoke(this, EventArgs.Empty);
            FirstCollection.CollectionChanged += UpdateSecond;
        }
        private void UpdateSecond(object sender, NotifyCollectionChangedEventArgs e)
        {
            SecondCollection.CollectionChanged -= UpdateFirst;
            Update(SecondCollection, e, _mapFromFirstToSecond, _newSecondItemFromFirst);
            SecondCollectionHasBeenUpdated?.Invoke(this, EventArgs.Empty);
            SecondCollection.CollectionChanged += UpdateFirst;
        }
    }
