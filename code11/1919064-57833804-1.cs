    public Book(string title)
    {
        // Resolves rule CA1507 violation
        Title = title ?? throw new ArgumentNullException(nameof(title), "All books must have a title.");
    }
