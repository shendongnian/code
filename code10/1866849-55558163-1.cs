    var sql = "EXEC p_myProc";
    var resultDictionary = new Dictionary<Guid, Result>();
    var results = connection.Query<Result, Header, Content, Result>(
            sql,
            (result, header, content) =>
            {
                if (!resultDictionary.TryGetValue(result.Guid1, out var existingResult))
                {
                    result.Headers = new List<Header>();
                    result.Content = new List<Content>();
                    resultDictionary.Add(result.Guid1, result);
                    existingResult = result;
                }
                // Noting OP has defined the Child tables as immutable IEnumerable<>
                (existingResult.Headers as List<Header>).Add(header);
                (existingResult.Content as List<Content>).Add(content);
                return existingResult;
            },
            splitOn: "Guid2,Guid3")
        .Distinct() // Strip duplicates by reference equality
        .ToList();
