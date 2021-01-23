    var s = new Source { Value = 1 };
    var values = Observable.FromEvent(h => s.ValueChanged += h,
                                      h => s.ValueChanged -= h)
                           .Select(e => e.NewValue)
                           .Publish(s.Value);
    using (values.Connect())                         // subscribes subject to event
    {
        using (values.Subscribe(Console.WriteLine))  // subscribes to subject
        {
            s.Value = 2;
        }                                            // unsubscribes from subject
        using (values.Subscribe(Console.WriteLine))  // subscribes to subject
        {
            s.Value = 3;
        }                                            // unsubscribes from subject
    }                                            // unsubscribes subject from event
