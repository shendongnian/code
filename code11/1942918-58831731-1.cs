    [Fact]
            public void CanSearchWithCustomAnalyzer()
            {
                Run(() =>
                {
                    const string CustomAnalyzerName = "my_email_analyzer";
                    const string CustomCharFilterName = "my_email_filter";
    
                    Index index = new Index()
                    {
                        Name = SearchTestUtilities.GenerateName(),
                        Fields = new[]
                        {
                            new Field("id", DataType.String) { IsKey = true },
                            new Field("message", (AnalyzerName)CustomAnalyzerName) { IsSearchable = true }
                        },
                        Analyzers = new[]
                        {
                            new CustomAnalyzer()
                            {
                                Name = CustomAnalyzerName,
                                Tokenizer = TokenizerName.Standard,
                                CharFilters = new[] { (CharFilterName)CustomCharFilterName }
                            }
                        },
                        CharFilters = new[] { new PatternReplaceCharFilter(CustomCharFilterName, "@", "_") }
                    };
    
                    Data.GetSearchServiceClient().Indexes.Create(index);
    
                    SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);
    
                    var documents = new[]
                    {
                        new Document() { { "id", "1" }, { "message", "My email is someone@somewhere.something." } },
                        new Document() { { "id", "2" }, { "message", "His email is someone@nowhere.nothing." } },
                    };
    
                    indexClient.Documents.Index(IndexBatch.Upload(documents));
                    SearchTestUtilities.WaitForIndexing();
    
                    DocumentSearchResult<Document> result = indexClient.Documents.Search("someone@somewhere.something");
    
                    Assert.Equal("1", result.Results.Single().Document["id"]);
                });
            }
