    var contentResult = locations as OkNegotiatedContentResult<List<Location>>;
    Assert.IsNotNull(contentResult, "contentResult should not be null.");
    Assert.IsInstanceOfType(contentResult.Content, typeof(List<Location>), "Wrong Model");      
    Assert.IsNotNull(contentResult.Content, "contentResult.Content is null");           
    Assert.AreEqual(1, contentResult.Content[0].Id);                               
    Assert.AreEqual(2, contentResult.Content.Count, "Got wrong number of locations");    
