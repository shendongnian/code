    IObservable<InMsg> inMessages;
    inMessages
        .GroupBy(msg => msg.GroupId)
        .Select(group =>
            {
                return group.Select(groupMsg => 
                    {
                        TimeSpan delay = TimeSpan.FromMilliseconds(groupMsg.Delay);
                        OutMsg outMsg = new OutMsg(); // map InMsg -> OutMsg here
                        return Observable.Return(outMsg).Delay(delay));
                    })
                    .Switch();
            })
            .Subscribe(outMsg => Console.Write("OutMsg received"));
