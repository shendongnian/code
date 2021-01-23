    public ObservableCollection<Message> Messages { get; set; }
    void QueueMessages(IEnumerable<Message> messages)
    {
        int intervalSeconds = 5;
        // generate the observable source
        var enumerator = messages.GetEnumerator();
        var source = Observable.Generate(
                enumerator,                                  // initial value
                i => enumerator.MoveNext(),                  // condition
                i => i,                                      // iterate
                i => enumerator.Current,                     // selector
                i => TimeSpan.FromSeconds(intervalSeconds))  // interval selector
            .ObserveOnDispatcher();
        // subscribe to the source
        source.Subscribe(
            // display messages as they arrive
            message => Messages.Add(message),
            // add a "complete" message when done
            () => Messages.Add(new Message("complete!"))
        );
    }
