IQueryable<Entity> SearchEntities (List<TimeFrame> times)
{
  var predicate = PredicateBuilder.False<Product>();
  foreach (string time in times)
  {
    TimeFrame temp = time;
    predicate = predicate.Or (p => (temp.From <= p.CreationDateTime) AND (p.CreationDateTime <= temp.To));
  }
  return dataContext.Entities.AsExpandable().Where (predicate);
}
  [1]: http://www.albahari.com/nutshell/predicatebuilder.aspx
  [2]: http://www.albahari.com/nutshell/linqkit.aspx
