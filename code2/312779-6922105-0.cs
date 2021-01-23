    public override int SaveChanges()
    {
        int recordsUpdated = 0;
    
        var journalEntries = new List<AuditJournal>();
    
        foreach (var entry in this.ChangeTracker.Entries<ITrackedEntity>().Where(e=>e.State != EntityState.Unchanged))
        {
            AuditJournal journal = new AuditJournal();
            journal.Id = Guid.NewGuid();
            journal.EntityId = entry.Entity.Id.Value;
            journal.EntityType = entry.Entity.EntityType;
            journal.ActionType = entry.State.ToString();
            journal.OccurredOn = DateTime.UtcNow;
            //journal.UserId = CURRENT USER
            //journal.PreviousEntityData = XML SERIALIZATION OF ORIGINAL ENTITTY
    
            journalEntries.Add(journal);
        }
    
        using (var scope = new TransactionScope())
        {
            recordsUpdated = base.SaveChanges();
    
            foreach (var journalEntry in journalEntries)
                this.AuditJournal.Add(journalEntry);
    
            base.SaveChanges(); //Save journal entries
    
            scope.Complete();
        }
    
        return recordsUpdated;
    }
    //Every entity that needs to be audited has to implement this interface
    public interface ITrackedEntity
    {
        string EntityType { get; }
        Guid? Id { get; set; }
    }
