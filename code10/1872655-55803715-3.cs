    // In Document entity...
    public void Delete(string comment)
    {
        Comment = comment;
        IsDeleted = true;
        DeletedAt = DateTime.Now;
        // no history reference.
    }
    // in DbContext
    public Document DeleteDocument(Document document, string comment)
    {
        document.Delete(comment);
        DocumentHistory.Add(new DocumentHistory
        {
           Document = document,
           Action = "DELETE",
           // ...
        });
    }
