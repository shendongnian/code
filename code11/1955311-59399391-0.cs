csharp
public class MyContext : DbContext
{
    public MyContext()
    {
        this.Configuration.UseDatabaseNullSemantics = true;
    }
}
