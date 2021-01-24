    var searchResponse = await elasticClient
        .SearchAsync<Document>(s => s
            .Query(q => q
                .Term(t => t
                    .Field(f => f.LogLevel.Suffix("keyword"))
                    .Value("Information"))));
    class Document
    {
        public string LogLevel { get; set; }
    }
