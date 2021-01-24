    public void AddNew(Entry entry)
    {
        entry.CreatedTimestamp = DateTime.Now.ToString();
        var account = _context.Accounts.Single(x => x.Id = entry.Account.Id);
        var category = _context.Categories.Single(x => x.Id = entry.Category.Id);
        entry.Account = account; 
        entry.Category = category;
        _context.Entries.Add(entry);
        _context.SaveChanges();
    }
