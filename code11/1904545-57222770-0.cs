    ContainerProperties containerDefinition = new ContainerProperties(new Guid().ToString(), "/id");
    containerDefinition.IndexingPolicy.ExcludedPaths.Add(new Cosmos.ExcludedPath()
    {
        Path = "/*"
    });
    ContainerResponse response = await cosmosDatabase.CreateContainerAsync(containerDefinition);
    FeedIterator<ContainerProperties> resultSet = cosmosDatabase.GetContainerQueryIterator<ContainerProperties>(($"select * from c where c.id = \"{response.Container.Id}\""));
    FeedResponse<ContainerProperties> queryProperties = resultSet.ReadNextAsync().Result;
    ContainerProperties containerSettings = queryProperties.Resource.ToList().FirstOrDefault();
    Assert.AreEqual(containerDefinition.IndexingPolicy.ExcludedPaths.First().Path, containerSettings.IndexingPolicy.ExcludedPaths.First().Path);
