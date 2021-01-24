    using (var context = new SearchContext())
    {
        var results = context.Logs
            .Where(x => x.Name.Contains(sRequest))
            .Select(x => new SearchResultDTO
            {
                ID = x.ID,
                Name = x.Name,
                Job = x.Job,
                Start = x.Start,
                End = x.End,
                Logs = x.LogLines.Select(y => y.Line).ToList(),
            }).ToList();
    
         var resultDto = SearchResultsDTO.Success(results);
         return resultsDto;
    }
