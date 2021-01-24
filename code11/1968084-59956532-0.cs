    {
        var createIndexResponse = await client.CreateIndexAsync("my_index", c => c
            .Settings(s => s.Analysis(a => a
                .Analyzers(an => an.Custom("my_analyzer", cu => cu.Tokenizer("my_tokenizer")))
                .Tokenizers(t => t.UaxEmailUrl("my_tokenizer", u => u.MaxTokenLength(3)))))
            .Mappings(m => m
                .Map<Document>(map => map
                    .Properties(p => p.Text(t => t.Name(n => n.Email).Analyzer("my_analyzer"))))));
        
        var indexResponse = await client.IndexAsync(new Document {Id = "1", Email = "robert.lyson@domain.com"},
            i => i.Refresh(Refresh.WaitFor));
        
        await Search(client, "robert.lyson");
        await Search(client, "robert");
        await Search(client, "lyson");
        await Search(client, "@domain.com");
        await Search(client, "domain.com");
        await Search(client, "rob");
    }
    private static async Task Search(ElasticClient client, string query)
    {
        var searchResponse = await client.SearchAsync<Document>(s => s
            .Query(q => q.Match(m => m.Field(f => f.Email).Query(query))));
    
        System.Console.WriteLine($"result for query \"{query}\": {string.Join(",", searchResponse.Documents.Select(x => x.Email))}");
    }
    
    public class Document
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }
