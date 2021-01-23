    var predicate = PredicateBuilder.False<Item>();
    foreach (int tagid in tagFilterConditions)
    {
        int temp = tagid;
        predicate = predicate.And(item => item.Tags.Contains(temp));
    }
    var query = dataContext.Items.Where(predicate);
