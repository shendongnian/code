    var s = new Source { Value = 1 };
    var values = Observable.FromEvent(h => s.ValueChanged += h,
                                      h => s.ValueChanged -= h)
                           .Select(_ => s.Value)
                           .Publish(1);
    using (values.Connect())
    {
        using (values.Subscribe(Console.WriteLine))
        {
            s.Value = 2;
        }
        using (values.Subscribe(Console.WriteLine))
        {
            s.Value = 3;
        }
    }
