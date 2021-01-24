    ```CSharp
    //Global setup of Auditing
    var auditDbCtxOptions = new DbContextOptionsBuilder<MyAuditDbContext>()
        .UseSqlServer(options.AuditDbConnectionString)
        .Options;
    Audit.Core.Configuration.Setup()
        .UseEntityFramework(x => x
            .UseDbContext<MyAuditDbContext>(auditDbCtxOptions)
            .AuditTypeNameMapper(typeName => 
            {
                return typeName;
            })
            .AuditEntityAction<AuditInfo>((ev, ent, auditEntity) =>
            {
                auditEntity.DatabaseAction = ent.Action;
            }));
    ```
