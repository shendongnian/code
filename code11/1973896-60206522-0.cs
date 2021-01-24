        private CoreContext _coreContext;
        public AccountController(CoreContext coreContext)
        {
             private CoreContext _coreContext;
then changed the following code from:
Microsoft.EntityFrameworkCore.DbContextOptions<CoreContext> options = new Microsoft.EntityFrameworkCore.DbContextOptions<CoreContext>();
using (CoreContext dbContext = new CoreContext(options)) 
{
    dbContext.Person.Add(person);
    dbContext.SaveChanges();
    id = person.PkPersonId;
}
To just:
_coreContext.Person.Add(person);
_coreContext.SaveChanges();
id = person.PkPersonId;
