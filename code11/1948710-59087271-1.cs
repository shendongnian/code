    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() == 0)
        {
            _bookRepository.InsertAsync(new Book("Title1"));
            _bookRepository.InsertAsync(new Book("Title2"));
        }
    }
