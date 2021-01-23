    // the user searchs for "ab"
    [Thread 1] Results.Clear();
    [Thread 1] Results.Add(Item[1]);
    [Thread 1] Results.Add(Item[2]);
    ...
    // the user changes the search term (to "abc" for example)
    [Thread 2] Results.Clear();
    [Thread 2] Results.Add(Item[3]);
    // but what would happen if the first BackGroundWorker hasn't finished yet,
    // this means that the first thread is still running
    [Thread 1] Results.Add(Item[5]); // this items doesn't match the second search
    [Thread 1] Results.Add(Item[6]); // criteria, but are added to the collection
    [Thread 2] Results.Add(Item[7]);
    // then you'll have two treads adding items to the Result collection
    [Thread 1] Results.Add(Item[2]);
    ...
    [Dispatcher Thread] autGlobal.ItemsSource = Results;
    [Dispatcher Thread] autGlobal.PopulateComplete();
