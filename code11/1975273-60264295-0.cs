	var serializerRegistry = BsonSerializer.SerializerRegistry;
	var documentSerializer = serializerRegistry.GetSerializer<MyDao>();
	var expectedFilter = Builders<MyDao>.Filter.Eq("UserId", existingInvestor2.InvestorId);
	this.mockCollection
		.Verify(x => x.UpdateOneAsync(It.Is<FilterDefinition<MyDao>>(a => a.Render(documentSerializer, serializerRegistry) == expectedFilter.Render(documentSerializer, serializerRegistry)), 
			It.IsAny<UpdateDefinition<MyDao>>(), 
			It.IsAny<UpdateOptions>(), 
			It.IsAny<CancellationToken>()));
