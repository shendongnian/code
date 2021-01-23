    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using ReactiveUI;
    namespace RxTest
    {
        public class TestEntity :  ReactiveObject, INotifyPropertyChanged, INotifyPropertyChanging
        {
            public string _File;
            public int _Rating = 0;
            public string File
            {
                get { return _File; }
                set { this.RaiseAndSetIfChanged(x => x.File, value); }
            }
            public int Rating
            {
                get { return this._Rating; }
                set { this.RaiseAndSetIfChanged(x => x.Rating, value); }
            }
            public TestEntity()
            {
            }
        }
        public class TestModel
        {
            private IEnumerable<TestEntity> collection { get; set; }
            private IDisposable sub;
            public TestModel()
            {
                this.collection = new ObservableCollection<TestEntity>() {
                new TestEntity() { File = "MySong.mp3", Rating = 5 },
                new TestEntity() { File = "Heart.mp3", Rating = 5 },
                new TestEntity() { File = "KarmaPolice.mp3", Rating = 5 }};
                var filter = new Func<int, bool>( Rating => (Rating == 0));
                var target = new ObservableCollection<TestEntity>();
                target.CollectionChanged += new NotifyCollectionChangedEventHandler(target_CollectionChanged);
                var react = new ReactiveCollection<TestEntity>(this.collection);
                react.ChangeTrackingEnabled = true;
                
                // update the target projection collection if an item is added
                react.ItemsAdded.Subscribe( v => { if (filter.Invoke(v.Rating)) target.Add(v); } );
                // update the target projection collection if an item is removed (and it was in the target)
                react.ItemsRemoved.Subscribe(v => { if (filter.Invoke(v.Rating) && target.Contains(v)) target.Remove(v); });
                // track items changed in the collection.  Filter only if the property "Rating" changes
                var ratingChangingStream = react.ItemChanging.Where(i => i.PropertyName == "Rating").Select(i => new { Rating = i.Sender.Rating, Entity = i.Sender });
                var ratingChangedStream = react.ItemChanged.Where(i => i.PropertyName == "Rating").Select(i => new { Rating = i.Sender.Rating, Entity = i.Sender });
                // pair the two streams together for before and after the entity has changed.  Make changes to the target
                Observable.Zip(ratingChangingStream,ratingChangedStream, 
                    (changingItem, changedItem) => new { ChangingRating=(int)changingItem.Rating, ChangedRating=(int)changedItem.Rating, Entity=changedItem.Entity})
                    .Subscribe(v => { 
                        if (filter.Invoke(v.ChangingRating) && (!filter.Invoke(v.ChangedRating))) target.Remove(v.Entity);
                        if ((!filter.Invoke(v.ChangingRating)) && filter.Invoke(v.ChangedRating)) target.Add(v.Entity);
                    });
                // should fire CollectionChanged Add in the target view model collection
                this.collection.ElementAt(0).Rating = 0;
                // should fire CollectionChanged Remove in the target view model collection
                this.collection.ElementAt(0).Rating = 5;
            }
            void target_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine(e.Action);
            }
        }
    }
