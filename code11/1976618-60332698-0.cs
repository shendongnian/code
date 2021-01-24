    void UpdateMessage(int recordId, string message)
    {
        using(var context = new AppContext())
        {
             var record = context.Records.Single(x => x.RecordId == recordId);
             record.Message = message;
             context.SaveChanges();
        }
    }
