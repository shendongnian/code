    List<Item> _Items = GetItems();
    Task.Factory.StartNew(()=> { 
            Task.WaitAll(
                _Items.Select(i => Task.Factory.StartNew(() => DoSomething(i))).ToArray()
            ); 
        }).ContinueWith(t => RaiseAllDoneEvent());
