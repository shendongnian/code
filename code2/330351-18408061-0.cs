    public ObservableCollection<Message> Messages { get; set; }
    void QueueMessages(IEnumerable<Message> messages)
    {
        int intervalSeconds = 5;
        // generate the observable source
        var enumerator = messages.GetEnumerator();
        var source = Observable.Generate(enumerator,
                i => enumerator.MoveNext(),
                i => i,
                i => enumerator.Current,
                i => TimeSpan.FromSeconds(intervalSeconds))
            .ObserveOnDispatcher();
        // subscribe to the source
        source.Subscribe(
            // display messages as they arrive
            message => Messages.Add(message),
            // add a "complete" message when done
            () => Messages.Add(new Message("complete!"))
        );
    }
