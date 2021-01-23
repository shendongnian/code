    var predicate = PredicateBuilder.True<Clients>();
    foreach(var criteria in searchCriteria) {
      if (criteria.Key=="city"){
        predicate = predicate.And(c => c.city==criteria.Value);
      } else if (criteria.Key=="address"){
        predicate = predicate.And(c => c.address==criteria.Value);
      }
    }
    var results = Context.Clients.Where(predicate);
