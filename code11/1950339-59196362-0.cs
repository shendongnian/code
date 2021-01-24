c#
services
    .AddEntityFrameworkSqlServer()
    .AddScoped<IMigrationsSqlGenerator, SchemaMigrationsSqlGenerator>()
    .AddScoped<MigrationsSqlGenerator, SqlServerMigrationsSqlGenerator>()
    .AddDbContext<AppDbContext>((serviceProvider, sqlOpt) =>
    {
        sqlOpt.UseInternalServiceProvider(serviceProvider)
              .UseSqlServer(
                  connectionString,
                  // Make sure thge migration table is also in that schema
                  opt => opt.MigrationsHistoryTable("__EFMigrationsHistory", yourSchema));
    });
And create a new class:
c#
/// <summary>
/// A class injected into the SQL command generation
/// in order to replace the schema with the one we want.
/// </summary>
public sealed class SchemaMigrationsSqlGenerator : IMigrationsSqlGenerator
{
    #region Fields
    private readonly MigrationsSqlGenerator mOriginal;
    private readonly ISchemaStorage mSchema;
    #endregion
    #region Init aned clean-up
    /// <summary>
    /// Constructor for dependency injection.
    /// </summary>
    /// <param name="original">Previously used SQL generator</param>
    /// <param name="schema">Where the schema name is stored</param>
    public SchemaMigrationsSqlGenerator(MigrationsSqlGenerator original, ISchemaStorage schema)
    {
        mOriginal = original;
        mSchema = schema;
    }
    #endregion
    #region IMigrationsSqlGenerator API
    /// <inheritdoc />
    /// <remarks>
    /// Overwrite the schema generated during Add-Migration,
    /// then call the original SQL generator.
    /// </remarks>
    IReadOnlyList<MigrationCommand> IMigrationsSqlGenerator.Generate(
        IReadOnlyList<MigrationOperation> operations, IModel model)
    {
        foreach (var operation in operations)
        {
            switch (operation)
            {
                case SqlServerCreateDatabaseOperation _:
                    break;
                case EnsureSchemaOperation ensureOperation:
                    ensureOperation.Name = mSchema.Schema;
                    break;
                case CreateTableOperation tblOperation:
                    tblOperation.Schema = mSchema.Schema;
                    break;
                case CreateIndexOperation idxOperation:
                    idxOperation.Schema = mSchema.Schema;
                    break;
                default:
                    throw new NotImplementedException(
                        $"Migration operation of type {operation.GetType().Name} is not supported by SchemaMigrationsSqlGenerator.");
            }
        }
        return mOriginal.Generate(operations, model);
    }
    #endregion
}
The code above forces the migrations to be executed in the schema injected with a trivial `ISchemaStorage` interface.
