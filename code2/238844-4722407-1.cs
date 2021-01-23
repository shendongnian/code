    ObservableCollection<int> collection = 
        new ObservableCollection<int>(new int[] { 1, 2, 3 });
    collection.GetObservableAddedValues().Subscribe(
        i => Console.WriteLine("{0} was added", i)
    );
