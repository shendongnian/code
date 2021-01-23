    public DbSet<Document> Documents { get; set; }
    List<Document> = Documents
        .Where(d => d.BusinessId = 818)
        .Where(d => d.CurrencyId != null)
        .ToList();
