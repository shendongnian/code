    context.Attachments.ApplyChanges(att);
    if (context.ObjectStateManager.GetObjectStateEntry(att).State == EntityState.Deleted)
    {
        var data = new AttachmentData() {Id = att.Id};
        context.AttachmentDataSet.Attach(data);
        context.AttachmentDataSet.DeleteObject(data);
    }
    context.SaveChanges();
