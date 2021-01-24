     var searchResult = elasticClient.Search<InquiryInformation>(s => s
                   .Query(q => q
                      .Nested(c => c
                         .InnerHits()
                         .Path(p => p.Files)
                         .Query(nq => nq
                           .MultiMatch(m => m
                             .Fields(f => f
                               .Field("files.fileContent")
                               .Field("files.fileName")
                             )
                             .Query("Samsung Galaxy S10")
                           )
                         )
                      )
                   )
               );
    
    foreach (var hit in searchResult.Hits)
    {
         var file = hit.InnerHits["files"].Documents<FileInformation>();
    }
