                var project = new BsonDocument
                {
                    {
                        "$project",
                        new BsonDocument
                        {
                            {"title", 1},
                            {"lastName", "$author.lastName"},
                        }
                    }
                };
    
                var pipelineLast = new[] { project };
    
    
                var resultLast = db.books.Aggregate<BsonDocument>(pipelineLast);
                var matchingExamples = await resultLast.ToListAsync();
                foreach (var example in matchingExamples)
                {
    // Display the result 
                }
