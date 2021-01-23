	var client = new FacebookClient(accessToken);
	dynamic userInfo = client.Get("me");
	Assert.That(userInfo, Is.Not.Null);
	var requiredDynamicProperties = new[] { "id", "name", "wtf" };
	var dictionary = (userInfo as IDictionary<string, Object>);
	CollectionAssert.IsSubsetOf(requiredDynamicProperties, dictionary.Keys); 
	// message will describe in details that no "wtf" found
