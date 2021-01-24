    using (var ctx = new ElectronicFileEntities())
    {
        var deleteFilesTime = Int32.Parse(_appSettings["UnFiledDocumentsRetainTime"]);
        var cutOffTime = DateTime.Now.AddHours(-deleteFilesTime);
        var documentsToDelete = ctx.Documents
            .Where(o => !o.IsDeleted && !o.IsFiled && o.LastModified < cutOffTime).ToList();
        foreach (var document in documentsToDelete)
        {
            document.Comment = "Deleted by loader service - not filed in time";
            ctx.DeleteDocument(document.DocumentId, DateTime.Now, 0);
            ctx.InsertDocumentHistory(document.DocumentId, "DELETE");
        }
        ctx.SaveChanges();
    }
