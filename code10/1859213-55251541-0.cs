	...
	
	[Fact]
	public void TestCategoryDetails()
	{
		// arrange
		var categoryRepository = new CategoryRepository(GetContextWithInMemoryProvider());
		
		// act
		categoryRepository.AddCategory(new GameCategory { Id = 1, Name = "Tester" });
		var categoryDetails = categoryRepository.GetDetails(1);
		// assert
		Assert.NotNull(categoryDetails);
	}
	
	private AppDbContext GetContextWithInMemoryProvider()
	{
		// create and configure context
		// see: https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/
	}
	
	...
