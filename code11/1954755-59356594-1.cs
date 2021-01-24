c#
// using Microsoft.EntityFrameworkCore;
var query = Repository
    .Where(p => p.Name.Contains(input.Name));
var books = await query.ToListAsync();
For a DI (ORM-independent) solution, inject `IAsyncQueryableExecuter` and do:
c#
// using Abp.Linq;
var query = Repository
    .Where(p => p.Name.Contains(input.Name));
var books = await _asyncQueryableExecuter.ToListAsync(query);
