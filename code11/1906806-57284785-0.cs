c#
public interface IClientContext
{
    DbSet<ClientTable> ClientTable { get; set; }
}
public class ClientContext : FrameworkContext, IClientContext
{
    public virtual DbSet<ClientTable> ClientTable { get; set; }
}
public abstract class BaseService
{
    private readonly FrameworkContext _context;
    public FrameworkContext Context { get { return _context; } }
    public BaseService(FrameworkContext context) { _context = context; }
    public void DoSomethingToClientTable()
    {
        if (_context is IClientContext)
        {
            var clientTable = ((IClientContext)_context).ClientTable;
            //Do something interesting here...
        }
    }
}
