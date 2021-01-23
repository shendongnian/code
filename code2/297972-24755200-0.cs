    public Task Search(string searchText, CancellationToken cancel)
    {
        // Pass the token on to the async webclient request etc.
    }
    var searchSub = Observable.ToAsync(c => this.booksService.Search(searchText, c))
                    .Subscribe( ... );
    // do something else
    searchSub.Dispose();
