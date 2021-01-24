    private async  Task<List<Film>> SearchFilms(string searchText)
    {
        try
        {
           var result = await BackendService.SearchFilms(searchText);
           return result;
        } 
        catch ( ... )
        {
             UiShowError( ... )
             return empty_list;
        }
    }
