    public IReadOnlyCollection<T> GetDocumentAsync<T>(Guid id)
        where T : class, IHasId // <--- Add this
    {
    	// Snip
    }
