    public class ApplicationDbContextUserWrapper : IDbContext
    {
        public ApplicationDbContext Context;
        public ApplicationDbContextUserWrapper(ApplicationDbContext context, 
               ICurrentUser currentUser)
        {
            context.CurrentUser = currentUser;
            this.Context = context;
         }
     int IDbContext.SaveChanges() => context.SaveChanges();
    ...
