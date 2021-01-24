    public void Delete(string comment)
    {
        Comment = comment;
        IsDeleted = true;
        DeletedAt = DateTime.Now;
        History.Add(new DocumentHistory
        {
           Action = "DELETE",
           // ...
        });
    }
