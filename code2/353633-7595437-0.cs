    logThing.When(
        lt => lt.AddEntry(Arg.Any<LogEntry>())).Do(
        call =>
        {
            actualEntries.Add(call.Arg<LogEntry>());
            throw new InvalidOperationException("testMessage");
        });
