    void UpdateMessage(int recordId, string message)
    {
        using(var context = new AppContext())
        {
             var record = context.Records.AsNoTracking().Single(x => x.RecordId == recordId);
             record.Message = message;
             context.Update(record); // or Attach() and set Modified state.
             context.SaveChanges();
        }
    }
