    private ApplicationDbContext _db;
    
    public class HelloController : Controller
    {
        _db = ApplicationDbContext.getInstance();
    }
    
