    list1.ToObservable().Zip( // Convert list1 to Observable
        Observable.Interval(TimeSpan.FromSeconds(1)), // Zip it with an observable that ticks every second
        (list, timerList) => list). // select list1 only
            Subscribe((item) =>
            {
                list2.Add(item); // on each tick, add an item to list2
            });
