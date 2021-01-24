c#
using System;
using Elasticsearch.Net;
using Nest;
namespace Example
{
    private static void Main()
    {
        var defaultIndex = "attachments";
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var settings = new ConnectionSettings(pool)
            .DefaultIndex(defaultIndex)
            .DisableDirectStreaming()
            .PrettyJson()
            .OnRequestCompleted(callDetails =>
            {
                if (callDetails.RequestBodyInBytes != null)
                {
                    Console.WriteLine(
                        $"{callDetails.HttpMethod} {callDetails.Uri} \n" +
                        $"{Encoding.UTF8.GetString(callDetails.RequestBodyInBytes)}");
                }
                else
                {
                    Console.WriteLine($"{callDetails.HttpMethod} {callDetails.Uri}");
                }
                Console.WriteLine();
                if (callDetails.ResponseBodyInBytes != null)
                {
                    Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
                             $"{Encoding.UTF8.GetString(callDetails.ResponseBodyInBytes)}\n" +
                             $"{new string('-', 30)}\n");
                }
                else
                {
                    Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
                             $"{new string('-', 30)}\n");
                }
            });
        var client = new ElasticClient(settings);
      if (client.Indices.Exists(defaultIndex).Exists)
      {
        var deleteIndexResponse = client.Indices.Delete(defaultIndex);
      }
        var createIndexResponse = client.Indices.Create(defaultIndex, c => c
            .Settings(s => s
                .Analysis(a => a
                    .Analyzers(ad => ad
                        .Custom("windows_path_hierarchy_analyzer", ca => ca
                            .Tokenizer("windows_path_hierarchy_tokenizer")
                        )
                    )
                    .Tokenizers(t => t
                        .PathHierarchy("windows_path_hierarchy_tokenizer", ph => ph
                            .Delimiter('\\')
                        )
                    )
                )
            )
            .Map<Document>(mp => mp
                .AutoMap()
                .Properties(ps => ps
                    .Text(s => s
                        .Name(n => n.Path)
                        .Analyzer("windows_path_hierarchy_analyzer")
                    )
                    .Object<Attachment>(a => a
                        .Name(n => n.Attachment)
                        .AutoMap()
                    )
                )
            )
        );
      var putPipelineResponse = client.Ingest.PutPipeline("attachments", p => p
        .Description("Document attachment pipeline")
        .Processors(pr => pr
          .Attachment<Document>(a => a
            .Field(f => f.Content)
            .TargetField(f => f.Attachment)
          )
          .Remove<Document>(r => r
            .Field(ff => ff
              .Field(f => f.Content)
            )
          )
        )
      );
      var base64File = Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\russc\Dropbox\Other Linqpad queries\example_one.docx"));
      var indexResponse = client.Index(new Document
      {
        Id = 1,
        Path = @"\\share\documents\examples\example_one.docx",
        Content = base64File
      }, i => i
        .Pipeline("attachments")
        .Refresh(Refresh.WaitFor)
      );
      var searchResponse = client.Search<Document>(s => s
        .Query(q => q
        .Match(m => m
          .Field(a => a.Attachment.Content)
          .Query("NEST")
        )
        )
      );
      foreach(var hit in searchResponse.Hits)
      {
        var attachment = hit.Source.Attachment;
        Console.WriteLine($"Attachment details for doc id {hit.Id}");
        Console.WriteLine($"date: {attachment.Date}");
        Console.WriteLine($"content type: {attachment.ContentType}");
        Console.WriteLine($"author: {attachment.Author}");
        Console.WriteLine($"language: {attachment.Language}");
        Console.WriteLine($"content: {attachment.Content}");
        Console.WriteLine($"content length: {attachment.ContentLength}");
      }
    }
    public class Document
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public Attachment Attachment { get; set; }
    }
}
