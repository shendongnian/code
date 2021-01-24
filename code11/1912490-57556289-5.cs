`
//Use var list = _context.MyDbSet("ConsoleAppEF.Student").ToList();
public static IQueryable MySet(this SchoolContext context, string typeName)
{
    var T = Type.GetType(typeName);
    // Get the generic type definition
    MethodInfo method = typeof(SchoolContext)
        .GetMethod("MySet", BindingFlags.Public | BindingFlags.Instance);
    // Build a method with the specific type argument you're interested in
    method = method.MakeGenericMethod(T);
    return method.Invoke(context, null) as IQueryable;
}
public static IQueryable<T> Set<T>(this SchoolContext context)
{
    // Get the generic type definition 
    MethodInfo method = typeof(SchoolContext)
        .GetMethod(nameof(SchoolContext.Set), BindingFlags.Public | BindingFlags.Instance);
    // Build a method with the specific type argument you're interested in 
    method = method.MakeGenericMethod(typeof(T));
    return method.Invoke(context, null) as IQueryable<T>;
}
public static IList ToList1(this IQueryable query)
{
    var genericToList = typeof(Enumerable).GetMethod("ToList")
        .MakeGenericMethod(new Type[] { query.ElementType });
    return (IList)genericToList.Invoke(null, new[] { query });
}
`
Sample DbContext:
`
public class SchoolContext : DbContext
{
    public SchoolContext() : base("SchoolContext")
    {
    }
    public DbSet<Student> Students { get; set; }
    public virtual new DbSet<TEntity> MySet<TEntity>() where TEntity : BaseEntity
    {
        return base.Set<TEntity>();
    }
}
`
Sample Entity:
`
public class Student : BaseEntity
{
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
}
public class BaseEntity
{
    public int Id { get; set; }
}
`
Use it:
`
class Program
{
    static void Main(string[] args)
    {
        Seed();
        var _context = new SchoolContext();
        var list = _context.MySet("ConsoleAppEF.Student").ToList1();
    }
    private static void Seed()
    {
        var _context = new SchoolContext();
        var students = new List<Student>
        {
            new Student{FirstMidName="Carson",LastName="Alexander"},
        };
        students.ForEach(s => _context.Students.Add(s));
        _context.SaveChanges();
    }
}
`
