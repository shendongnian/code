csharp
//Entity class representation
public class Employee
{
	public int Id { get; set; }
}
//Entity Framework context
public class SecondContext : DbContext
{
	public SecondContext(DbContextOptions<SecondContext> options) : base (options)
	{
	}
	
 	public DbSet<Employee> Employees { get; set; }
}
At the end, you will have two contexts in your application.
