    private async  Task<IEnumerable<Film>> SearchFilms(string searchText)
    {
        var result = Films
                     .Where(x => x.Title.ToLower().Contains(searchText.ToLower()))
                     .ToList();
        await Task.CompletedTask;  // avoid warning (*1)
        return result;
    }
