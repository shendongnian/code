csharp
public class UserRole
{
   public int Id { get; set; }
   public int UserId { get; set; }
   public User User { get; set; } 
   public int RoleId { get; set; }
   public Role Role { get; set; }
}
2: Adjust the entity-type User
csharp
public class User 
{
   // more code probably here
   public virtual ICollection<UserRole> UserRoles { get; set; } // virtual keyword necessary for lazy loading, can be left out if not wanted
}
3: Adjust the entity-type Role
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
   public virtual ICollection<UserRole> UserRoles { get; set; } // virtual keyword necessary for lazy loading, can be left out if not wanted
}
4: Adjust your `OnModelCreating(ModelBuilder builder)` method within your `DbContext` and remove your old relationship-mapping and add the new one
csharp
protected override void OnModelCreating(ModelBuilder builder)
{
   // existing code here
   modelBuilder.Entity<UserRole>()
     .HasOne(ur => ur.User)
     .WithMany(u => u.UserRoles)
     .HasForeignKey(ur => ur.RoleId);
   modelBuilder.Entity<UserRole>()
     .HasOne(ur => ur.Roles)
     .WithMany(r => r.UserRoles)
     .HasForeignKey(ur => ur.UserId);
}
5: Create the new model and update the database, you probably will have to drop the existing one
6: Do the query like that if you want to include roles in your users
csharp
var usersWithRoles = context.Set<User>().Include(u => u.UserRoles).ThenInclude(ur => ur.Roles);
[Sadly it doesn't work yet without the mapping-entity][1]
[More samples can be found here][2]
  [1]: https://stackoverflow.com/a/53972658/5397642
  [2]: http://*%20SOLWEB-1554:%20Energycomparison%20-%20disabled%20mpptracker%20channels%20are%20ignored
  [3]: https://github.com/alsami/Stackoverflow_56131817_Ef_Problem
