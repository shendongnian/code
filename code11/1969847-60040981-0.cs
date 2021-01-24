    public PersonRepository(Func<AppContext> appContextFactory)
    {
        this.appContextFactory = appContextFactory;
    }
    public async Task<IEnumerable<Person>> GetAll()
    {
       using (var appContext = appContextFactory())
       {
           return await appContext.People.ToListAsync();
       }
    }
