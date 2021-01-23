    [EnableClientAccess]
    public class ModelService : LinqToEntitiesDomainService<dpirtEntities>
    {
    	public void InsertZone(Zone zone)
            {
                if ((zone.EntityState != EntityState.Detached))
                {
                    this.ObjectContext.ObjectStateManager.ChangeObjectState(zone, EntityState.Added);
                }
                else
                {
                    this.ObjectContext.Zones.AddObject(zone);
                }
            }
    
            public void UpdateZone(Zone currentZone)
            {
                Zone originalZone = this.ChangeSet.GetOriginal(currentZone);
                if ((currentZone.EntityState == EntityState.Detached))
                {
                    if (originalZone != null)
                    {
                        this.ObjectContext.Zones.AttachAsModified(currentZone, originalZone);
                    }
                    else
                    {
                        this.ObjectContext.Zones.Attach(currentZone);
                    }
                }
    
                foreach (Document doc in this.ChangeSet.GetAssociatedChanges(currentZone, o => o.Documents))
                {
                    ChangeOperation op = this.ChangeSet.GetChangeOperation(doc);
                    switch (op)
                    {
                        case ChangeOperation.Insert:
                            if ((doc.EntityState != EntityState.Added))
                            {
                                if ((doc.EntityState != EntityState.Detached))
                                {
                                    this.ObjectContext.ObjectStateManager.ChangeObjectState(doc, EntityState.Added);
                                }
                                else
                                {
                                    this.ObjectContext.AddToDocuments(doc);
                                }
                            }
                            break;
                        case ChangeOperation.Update:
                            this.ObjectContext.Documents.AttachAsModified(doc, this.ChangeSet.GetOriginal(doc));
                            break;
                        case ChangeOperation.Delete:
                            if (doc.EntityState == EntityState.Detached)
                            {
                                this.ObjectContext.Attach(doc);
                            }
                            this.ObjectContext.DeleteObject(doc);
                            break;
                        case ChangeOperation.None:
                            break;
                        default:
                            break;
                    }
                }
            }
    
            public void DeleteZone(Zone zone)
            {
                if ((zone.EntityState == EntityState.Detached))
                {
                    this.ObjectContext.Zones.Attach(zone);
                }
                this.ObjectContext.Zones.DeleteObject(zone);
            }
    }
