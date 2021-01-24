        public class ColumnOrderMigrationAssembly : MigrationsAssembly
        {
            private readonly DbContext _context;
            public ColumnOrderMigrationAssembly(ICurrentDbContext currentContext,
                IDbContextOptions options, IMigrationsIdGenerator idGenerator,
                IDiagnosticsLogger<DbLoggerCategory.Migrations> logger)
            : base(currentContext, options, idGenerator, logger)
            {
                _context = currentContext.Context;
            }
            public override Migration CreateMigration(TypeInfo migrationClass,
                string activeProvider)
            {
                var migration = base.CreateMigration(migrationClass, activeProvider);
                var productTableMigration = migration.UpOperations.FirstOrDefault(m => m.GetType() == typeof(CreateTableOperation) 
                && ((CreateTableOperation)m).Name == "Products") as CreateTableOperation;
                if (productTableMigration != null)
                {
                    var columns =new List<AddColumnOperation>(productTableMigration.Columns.OrderBy(o => o.Name));
                    productTableMigration.Columns.Clear();
                    productTableMigration.Columns.AddRange(columns);
                }
                return migration;
            }
        }
