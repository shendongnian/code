    public interface IUserDA
    {
      IQueryable<User> Users { get; }
    }
    public class MyDbContext : IUserDA
    {
      public DbSet<User> Users { get; set; }
      IQueryable<User> IUserDA.Users
      {
         get
         {
            return Users;  // references the DbSet
         }
      }
    }
