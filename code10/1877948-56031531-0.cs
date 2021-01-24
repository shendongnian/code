    var contentResult = locations as OkNegotiatedContentResult<List<Location>>;
    Assert.IsInstanceOfType(contentResult.Content, typeof(OkNegotiatedContentResult<List<Location>>), "Wrong Model");      
    Assert.IsNotNull(contentResult.Content, "contentResult is null");           
    Assert.AreEqual(1, contentResult.Content[0].Id);                               
    Assert.AreEqual(2, contentResult.Content.Count(), "Got wrong number of locations");    
