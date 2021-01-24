`
public class MyFirstContext : DbContext
{
    public DbSet<User> Users { get; set; }
}
public class MySecondContext : MyFirstContext
{
    public DbSet<UserBook> UserBooks { get; set; }
}
`
Of course, your second context could be in a different assembly. Now you only need `MySecondContext` in your application. You will be able to join `Users` and `UserBooks`.
