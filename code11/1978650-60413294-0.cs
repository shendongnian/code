c#
public override ICollection<ContactDetailModel> GetAll(ICollection<int> ids)
{
	return _context
		.Set<TEntity>()
		.IgnoreDeletedEntities()
        .ToList()                
		.Where(x => ids.Distinct().Contains(x.ContactId))                
		.Select(EntityToDTOMapper)
		.ToList();
}
Notice the explicit call to `ToList` after `IgnoreDeletedEntities`, this needs to be done to explicitly switch to client side evaluation so your `Where` statement will properly execute and not throw any errors. This is because `x => ids.Distinct().Contains(x.ContactId)` cannot be translated to SQL (or whatever) by your version of EF.
Number 2 could be solved like so:
c#
public override ICollection<ContactDetailModel> GetAll(ICollection<int> ids)
{
    ids = ids.Distinct();
	return _context
		.Set<TEntity>()
        .IgnoreDeletedEntities()
        .Where(x => ids.Contains(x.ContactId))
        .Select(EntityToDTOMapper)
        .ToList();
}
Notice how I moved the use of `ids.Distinct()` from the `Where` to the top, as that was the part EF couldn't translate
