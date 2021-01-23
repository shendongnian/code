    var list = new List<int> { 1, 2, 3 };
    var obs = list.ToObservable().Select(i => new Tuple<int,IObservable<int>>(i,list.ToObservable()));
    
    obs.SubscribeOn(Scheduler.NewThread).Subscribe(t => {
      Console.WriteLine(t.Item1);
      SaveItems(t.Item2);
    });
