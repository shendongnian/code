    using (var ctx = new ElectronicFileEntities())
    {
        var deleteFilesTime = Int32.Parse(_appSettings["UnFiledDocumentsRetainTime"]);
        var cutOffTime = DateTime.Now.AddHours(-deleteFilesTime);
        var documentsToDelete = ctx.Documents
            .Include(o => o.History)
            .Where(o => !o.IsDeleted && !o.IsFiled && o.LastModified < cutOffTime).ToList();
        foreach (var document in documentsToDelete)
            document.Delete("Deleted by loader service - not filed in time");
        ctx.SaveChanges();
    }
