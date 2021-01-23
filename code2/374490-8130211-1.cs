    protected readonly IRMDbContext context;
    public class Repository(IRMDbContext rMDbContext)
    {
        this.context = rMDbContext;
    }
