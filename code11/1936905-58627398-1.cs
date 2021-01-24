    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
      {
      public override int SaveChanges()
            {
                var entities = ChangeTracker.Entries().Where(x => x.Entity is Transactions && x.State == EntityState.Added) ;
                IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                foreach (var entity in entities)
                {
                  hubContext.Clients.All.notifyClients(entity);
                }
                return base.SaveChanges();
             }
        }
