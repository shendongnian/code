//this just gets a reference the DbSet, which implements IQueryable<User>
var queryable = _dbContext.Users;
//iterate over the filters and add each as a separate WHERE clause
foreach(var f in filters)
{
    //this just adds to the existing expression tree..
    queryable = queryable.Where(u=>u.Name.Contains(f));
}
//this will actually hit the database.
var results = queryable.ToList();
This should generate *something like* this in SQL (entirely pseudo-code)
select 
  u.*
from 
  users u
where 
  (u.username like "%Sue%")
  or (u.username like "%Bob%")
Hope this helps...
