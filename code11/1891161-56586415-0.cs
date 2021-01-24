    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.EntityFrameworkCore.Migrations.Operations;
    using Microsoft.EntityFrameworkCore.Storage;
    namespace test
    {
    /// <summary>
    /// Custom MigrationSqlGenerator to add semi-colons to the end of 
    /// all migration statements.
    /// </summary>
    public class CustomMySqlMigrationSqlGenerator : MySqlMigrationsSqlGenerator
    {
        private readonly MigrationsSqlGeneratorDependencies _dependencies;
        public CustomMySqlMigrationSqlGenerator(MigrationsSqlGeneratorDependencies dependencies, 
            IMigrationsAnnotationProvider migrationsAnnotations, 
            IMySqlOptions options): base(dependencies, migrationsAnnotations, options)
        {
            _dependencies = dependencies;
        }
        public override IReadOnlyList<MigrationCommand> Generate(IReadOnlyList<MigrationOperation> operations, IModel model = null)
        {
            List<MigrationCommand> result = new List<MigrationCommand>();
            IEnumerable<MigrationCommand> statements = base.Generate(operations, model);
            foreach (MigrationCommand statement in statements)
            {
                var factory = _dependencies.CommandBuilderFactory.Create();
                factory.Append((statement.CommandText.TrimEnd() + ";").Replace(";;", ";"));
                result.Add(new MigrationCommand(factory.Build(), statement.TransactionSuppressed));
            }
            return result;
        }
      }
    }
