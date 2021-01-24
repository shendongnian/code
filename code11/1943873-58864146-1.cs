C#
interface IDbContextFactory {
    DbContext CreateContext();
}
//...
public void Method() {
    using (var context = contextFactory.CreateContext()) {
        context.Posts.Where(/* something */)
            .ForEach(entity => {
                var result = CriticalAPI(entity.Id);
                entity.Token = result;
            });
        context.SaveChanges();
    }
}
public int CriticalAPI(int id) {
    using (var context = dbContextFactory.CreateContext()) {
        var token = /* do something critical */
        context.Logs.Add(new Log(){
            entityId = id
        });
        context.SaveChanges();
        return token;
    }
}
  [1]: https://en.wikipedia.org/wiki/Abstract_factory_pattern
