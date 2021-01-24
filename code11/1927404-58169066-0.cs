    QueryContainer Query(QueryContainerDescriptor<Document> q) =>
        q.Term(t => t.Field(f => f.Name).Value("something"));
    
    var actual = Query(new QueryContainerDescriptor<Document>()) as IQueryContainer;
    
    Assert.AreEqual("something", actual.Term.Value);
