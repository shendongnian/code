    var newList = list.Select(x =>
                            new PropertyDetails()
                            {
                                Type = x.Type,
                                Length = x.Length,
                                Sequence = x.Sequence,
                                Index = list.Take(x.Sequence).Select(y => y.Length).Aggregate((a, b) => a + b)
                            }
    );
