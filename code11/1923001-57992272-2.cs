    private async  Task<List<Film>> SearchFilms(string searchText)
    {
        var result = Films
                     .Where(x => x.Title.ToLower().Contains(searchText.ToLower()))
                     .ToList();
        await Task.CompletedTask;  // emulating async 
        return result;
    }
