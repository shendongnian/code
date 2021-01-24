var predicate = PredicateBuilder.New<Person>();
foreach (var filter in filters)
{
    predicate = predicate.Or(p =>
	   p.Gender == filter.Gender &&  filter.Name == p.Name));
}
people = _dbContext.People.Where(predicate).Select(r => r.Id).Distinct().ToArrayAsync();
Works like a charm. Thanks.
