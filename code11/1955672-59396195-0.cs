csharp
public async Task<myObj> Get(long id, string lang = null)
{
    var res = await db.Collection.AsQueryable()
                                 .Where(m =>
                                        m.Id == id &&
                                        m.Languages.Any(l => l.b == lang))
                                 .SingleOrDefaultAsync();
    return res ?? new myObj { _Id = id, Languages = null };
}
