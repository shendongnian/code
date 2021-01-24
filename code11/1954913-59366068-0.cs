var baseQuery = _context.AuditTransaction
    .Include(at => at.AuditEntityEntries)
        .ThenInclude(aee => aee.AuditPropertyEntries)
    .Where(at => auditTransactionFilter.Id == 0 || at.Id == auditTransactionFilter.Id)
    .Where(at => string.IsNullOrWhiteSpace(auditTransactionFilter.UserName) || at.UserName == auditTransactionFilter.UserName);
            
var queryPredicateBuilder = PredicateBuilder.New<AuditTransaction>();
foreach (var entityFilter in auditTransactionFilter.AuditEntityEntries)
{
    if(entityFilter.AuditPropertyEntries?.Count == 0)
    {
        queryPredicateBuilder
            .Or(at => at.AuditEntityEntries
                    .Any(ataee => ataee.TableName.Contains(entityFilter.TableName)
                    && (ataee.KeyValues == entityFilter.KeyValues || string.IsNullOrWhiteSpace(entityFilter.KeyValues))));
    }
}
foreach (var propertyFilter in auditTransactionFilter.AuditEntityEntries.SelectMany(atfaee => atfaee.AuditPropertyEntries))
{
    queryPredicateBuilder
        .Or(at => at.AuditEntityEntries
            .Any(ataee => ataee.TableName.Contains(propertyFilter.AuditEntityEntry.TableName)
            && (ataee.KeyValues == propertyFilter.AuditEntityEntry.KeyValues || string.IsNullOrWhiteSpace(propertyFilter.AuditEntityEntry.KeyValues))
            && ataee.AuditPropertyEntries
                .Any(atape => atape.PropertyName == propertyFilter.PropertyName && atape.PropertyValues.Contains(propertyFilter.PropertyValues))
        ));
}
return baseQuery.AsExpandable().Where(queryPredicateBuilder);
And that totally did the trick!
I don't like it, but it works and I'm not sure how else to generate a dynamic linq to sql statement that will translate correctly and have this many levels of nested any checks against an outside list of non-primitives.
I'm still up for better answers.
