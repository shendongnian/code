    public Validation(ADbContext db)
    {
        _connectionString = db.Database.Connection.ConnectionString;
    }
    
    private readonly string _connectionString;
    
    public ILookup<string, List<string>> Run()
    {
        // A tolerance to deal with Entity Framework renaming
        var modelValidation = GetModelProperties<ADbContext>(tolerance);
        var isValid = !modelValidation.Any(v => v.Any(x => x.Count > 0));
        if (!isValid)
            Logger.Activity(BuildMessage(modelValidation));
        return modelValidation;
    }
    public string BuildMessage(ILookup<string, List<string>> modelValidation)
    {
        // build a message to be logged
    } 
    public List<string> GetMissingColumns(IEnumerable<string> props, IEnumerable<string> columns, int tolerance)
    {
        // compare whether the entity properties have corresponding columns in the database
        var missing = props.Where(p => !columns.Any(c => p.StartsWith(c) && Math.Abs(c.Length - p.Length) <= tolerance)).ToList();
        return missing;
    }
    public string[] GetSQLColumnNames(Type t)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        var table = t.Name;
        DynamicParameters dparams = new DynamicParameters();
        dparams.Add("Table", table);
        var query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @Table ";
        // Using dapper to retrieve list of columns from that table
        List<string> columns = connection.Query<string>(query, dparams).ToList();
        return columns.ToArray();
    }
        
    static string[] GetEntityPropertyNames(Type t)
    {
        var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanRead && !p.PropertyType.FullName.Contains("My.Namespace") && !p.PropertyType.FullName.Contains("Collection"))
                .Select(p => p.Name)
                .ToArray();
        // these conditions excludes navigation properties: !p.PropertyType.FullName.Contains("My.Namespace") && !p.PropertyType.FullName.Contains("Collection")
        return properties;
    }
    
    ILookup<string, List<string>> GetModelProperties<T>(int tolerance, T source = default(T))
    {
        var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.PropertyType.IsGenericType)
                .Select(p => p.PropertyType.GetGenericArguments()[0])
                .Select(p => new
                {
                    Entity = p.Name,
                    Properties = GetEntityPropertyNames(p),
                    Columns = GetSQLColumnNames(p),
                })
                .ToArray();
     
        return properties.ToLookup(p => p.Entity, p => GetMissingColumns(p.Properties, p.Columns, tolerance));
    }
