	[Fact]
	public async Task TestGetItemIdNotFound()
	{
		// Arrange
		long id = 99;
		var type = typeof(TController);
		ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(ApiDbContext), typeof(IMapper) });
		Assert.NotNull(constructorInfo);
		object classObject = constructorInfo.Invoke(new object[] { Context, Mapper });
		MethodInfo methodInfo = type.GetMethod("GetById");
		Assert.NotNull(methodInfo);
		// Act
		dynamic task = methodInfo.Invoke(classObject, new object[] { id });
		var controllerResponse = await task.ConfigureAwait(false);
		// Assert
		Assert.IsType<NotFoundObjectResult>(controllerResponse);
		var objectResponse = controllerResponse as ObjectResult;
		Assert.Equal(404, objectResponse.StatusCode);
	}
