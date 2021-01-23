    var predicate = PredicateBuilder.True<Command>(); //use True for ANDs
    foreach(var keyword in foo) {
      predicate = predicate.And(c => c.CommandParts.Any(p => p.part==keyword));
    }
    var results = db.Commands.Where(predicate);
