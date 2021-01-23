    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CaseSensitiveAttribute : Attribute
    {
        public CaseSensitiveAttribute()
        {
            IsEnabled = true;
        }
        public bool IsEnabled { get; set; }
    }
    public class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AlterColumnOperation alterColumnOperation)
        {
            base.Generate(alterColumnOperation);
            AnnotationValues values;
            if (alterColumnOperation.Column.Annotations.TryGetValue("CaseSensitive", out values))
            {
                if (values.NewValue != null && values.NewValue.ToString() == "True")
                {
                    using (var writer = Writer())
                    {
                        //if (System.Diagnostics.Debugger.IsAttached == false) System.Diagnostics.Debugger.Launch();
                        // https://github.com/mono/entityframework/blob/master/src/EntityFramework.SqlServer/SqlServerMigrationSqlGenerator.cs
                        var columnSQL = BuildColumnType(alterColumnOperation.Column); //[nvarchar](100)
                        writer.WriteLine(
                            "ALTER TABLE {0} ALTER COLUMN {1} {2} COLLATE SQL_Latin1_General_CP1_CS_AS {3}",
                            alterColumnOperation.Table,
                            alterColumnOperation.Column.Name,
                            columnSQL,
                            alterColumnOperation.Column.IsNullable.HasValue == false || alterColumnOperation.Column.IsNullable.Value == true ? " NULL" : "NOT NULL" //todo not tested for DefaultValue
                            );
                        Statement(writer);
                    }
                }
            }
        }
    }
    public class CustomApplicationDbConfiguration : DbConfiguration
    {
        public CustomApplicationDbConfiguration()
        {
            SetMigrationSqlGenerator(
                SqlProviderServices.ProviderInvariantName,
                () => new CustomSqlServerMigrationSqlGenerator());
        }
    }
