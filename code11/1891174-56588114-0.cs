    private readonly ILogger<ItemQueries> _logger;
    private readonly string _connectionString = default(string);
    public delegate ItemQueries Factory(string connectionString); // --> here, you create the delegate factory
    // connectionString needs to be the first parameter
    public ItemQueries(string connectionString, ILogger<ItemQueries> logger) 
    {
        _logger = logger;
        _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
    }
