    var results = solr.Query(new SolrQueryByField("features", "noise"), new QueryOptions {
        Highlight = new HighlightingParameters {
            Fields = new[] {"features"},
        }
    });
    foreach (var h in results.Highlights[results[0].Id]) {
        Console.WriteLine("{0}: {1}", h.Key, string.Join(", ", h.Value.ToArray()));
    }
