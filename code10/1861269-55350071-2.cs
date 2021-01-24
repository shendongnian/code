    Audit.Core.Configuration.Setup()
        .UseEntityFramework(_ => _
            .AuditTypeExplicitMapper(map => map
                .Map<Entity, Entity_AT>((evt, entry, auditEntity) =>
                {
                    auditEntity.ATCreationDate = ...;
                    auditEntity.ATFlag = ...;
                    auditEntity.RequesterID = evt.CustomFields["RequesterId"] as string;
                    auditEntity.ATComment = evt.CustomFields["ATComment"] as string;
                })));
                        
