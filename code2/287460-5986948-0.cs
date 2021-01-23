    public override object ProvideValue( IServiceProvider serviceProvider )
    {
        var contextProvider = (IXamlSchemaContextProvider)serviceProvider.GetService( typeof( IXamlSchemaContextProvider ) );
        var type = contextProvider.SchemaContext.GetType().Assembly.GetType( "System.Windows.Baml2006.Baml2006SchemaContext" );
        var property = type.GetProperty( "LocalAssembly", BindingFlags.Instance | BindingFlags.NonPublic );
        var assembly = (Assembly)property.GetValue( contextProvider, null );
        ...
    }
