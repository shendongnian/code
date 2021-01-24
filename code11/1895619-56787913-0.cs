    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Linq;
    
    namespace core
    {
        public static class Extensions
        {
            public static void AddTemporalTableSupport(this MigrationBuilder builder, string tableName, string historyTableSchema)
            {
                builder.Sql($@"ALTER TABLE {tableName} ADD 
                                SysStartTime datetime2(0) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
                                SysEndTime datetime2(0) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
                                PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime);");
                builder.Sql($@"ALTER TABLE {tableName} SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = {historyTableSchema}.{tableName} ));");
            }
    
            public static DbContext GetDbContext<T>(this DbSet<T> dbSet) where T : class
            {
                var infrastructure = dbSet as IInfrastructure<IServiceProvider>;
                return (infrastructure.Instance.GetService(typeof(ICurrentDbContext)) as ICurrentDbContext).Context;
            }
    
            public static string GetTableName<T>(this DbSet<T> dbSet) where T : class
            {
                var entityType = dbSet.GetDbContext().Model.GetEntityTypes().FirstOrDefault(t => t.ClrType == typeof(T)) 
                    ?? throw new ApplicationException($"Entity type {typeof(T).Name} not found in current database context!");
                var tableNameAnnotation = entityType.GetAnnotation("Relational:TableName");
                return tableNameAnnotation.Value.ToString();
            }
    
            public static IQueryable<T> ForSysTime<T>(this DbSet<T> dbSet, DateTime time) where T : class
            {
                return dbSet.FromSql($"SELECT * FROM dbo.[{dbSet.GetTableName()}] FOR SYSTEM_TIME AS OF {{0}}", time.ToUniversalTime());
            }
    
    
        }
    }
