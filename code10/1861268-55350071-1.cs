    Audit.Core.Configuration.DataProvider = new EntityFrameworkDataProvider()
    {
        AuditTypeMapper = t => t == typeof(Entity) ? typeof(Entity_AT) : null,
        AuditEntityAction = (evt, entry, auditEntity) =>
        {
            var a = (dynamic)auditEntity;
            a.ATCreationDate = ...;
            a.ATFlag = ...;
            a.RequesterID = evt.CustomFields["RequesterId"] as string;
            a.ATComment = evt.CustomFields["ATComment"] as string;
            return true; 
        }
    };
