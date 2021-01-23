    var someMessages = bus.AsObservable<SomeMessage>();
    var otherMessages = bus.AsObservable<AnotherMessage>();
    var joined = from s in someMessages
                 join o in otherMessages
                   on s.CorrelationId equals o.CorrelationId
                 select new { s.Something, o.OtherThing };
    joined.Subscribe(x => Console.WriteLine(x));
