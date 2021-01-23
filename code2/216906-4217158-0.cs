    var predicate = PredicateBuilder.False<Entry>();
    foreach(var command in commands)
    {
        foreach(var state in command.states)
        {
            predicate = predicate.Or(p => p.Command == command.Command && p.State == state);
        }
    }
    var query = table.Where(predicate);
