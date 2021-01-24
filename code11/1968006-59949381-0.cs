    var now = DateTime.Now;
    repository.Insert(entity);
    
    // At this point, I think both the entity itself and if you can read it back from the store should have acceptable values or the test fails.
    Assert.IsTrue(entity.CreatedBy == "me");
    Assert.IsTrue(entity.LastUpdatedBy == "me");
    Assert.IsTrue((now - entity.CreatedAt).TotalMilliseconds <= tolerance);
    Assert.IsTrue((now - entity.LastUpdatedAt).TotalMilliseconds <= tolerance);
    
    var newEntity = repository.Get(entity.Id);
    // same tests here.
    
    // Repeat similarly for update, and ensure created attributes don't change.
