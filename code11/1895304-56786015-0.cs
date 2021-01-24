        public ISearchIndexClient CreateSearchIndexClient()
        {
            string searchServiceName = "MySearchServiceName";
            string queryApiKey = "MySearchServiceKey";
            string indexName = "MyIndexName";
            SearchIndexClient indexClient = new SearchIndexClient(searchServiceName, indexName, new SearchCredentials(queryApiKey));
            return indexClient;
        }
        public async Task StartAsync(ITurnContext turnContext, string searchText){
            ISearchIndexClient infoClient = CreateSearchIndexClient();
            
            string indexname = infoClient.IndexName;
            DocumentSearchResult<Document> results = infoClient.Documents.Search(searchText);
            await turnContext.SendActivityAsync(MessageFactory.Text($"Here should be the results: {results} \n...and then my index: {indexname}."));
        }
