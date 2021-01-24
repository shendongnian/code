    // Persistent state:
    Dictionary<String,Assembly> loadedAssemblies = new Dictionary<String,Assembly>();
    Dictionary<(String assembly, String typeName),Type> typesByAssemblyAndName = new Dictionary<(String assembly, String typeName),Type>();
    // The function:
    static Type GetExpectedTypeFromAssemblyFile( String assemblyFileName, String typeName )
    {
        var t = ( assemblyFileName, typeName );
        if( !typesByName.TryGetValue( t, out Type type ) )
        {
            if( !loadedAssemblies.TryGetValue( assemblyFileName, out Assembly assembly ) )
            {
                assembly = Assembly.LoadFrom( assemblyFileName );
                loadedAssemblies[ assemblyFileName ] = assembly;
            }
            type = assembly.GetType( typeName ); // throws if the type doesn't exist
            typesByName[ t ] = type;
        }
        return type;
    }
    // Usage:
    static IDbConnection CreateSqlConnection()
    {
        const String typeName         = "System.Data.SqlClient.SqlConnection";
        const String assemblyFileName = "System.Data.SqlClient.dll";
        Type sqlConnectionType = GetExpectedTypeFromAssemblyFile( assemblyFileName, typeName );
        Object sqlConnectionInstance = Activator.CreateInstance( sqlConnectionType ); // Creates an instance of the specified type using that type's default constructor.
        return (IDbConnection)sqlConnectionInstance;
    }
