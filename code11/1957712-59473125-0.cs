    var result = controller.GetPost(1);
    Assert.That(result, Is.Not.Null, "Unexpected null result");
    var retrievedPost = result as OkNegotiatedContentResult<Post>;
    Assert.That(retrievedPost, Is.Not.Null, "Unexpected null retrievedPost");
    Assert.That(retrievedPost.Id, Is.EqualTo(1), "retrievedPost.Id is unexpected")
