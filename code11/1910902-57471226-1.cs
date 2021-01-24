    public class LibraryAssetServiceTests
    {
      public LibraryAssetServiceTests()
      {
         _factory = new TestDataContextFactory();
      }
      private TestDataContextFactory _factory;
      [Fact]
      public async void GetAssetById_ExistingAsset_ReturnAsset()
      {
         // Arrange
         using (var context = _factory.Create())
         {
            var asset = new LibraryAsset
            {
               Id = 40,
               Author = new Author { Id = 1 },
               Photo = new Photo { Id = 1 }
            };
            context.Add(asset);
            context.SaveChanges();
         }
         // Act
         using (var context = _factory.Create())
         {
            var service = new LibraryAssetService(context);
            var actual = await service.GetAsset(40);
            // Assert
            Assert.Equal(40, actual.Id);
            Assert.Equal(1, actual.Author.Id);
            Assert.Equal(1, actual.Photo.Id);
         }
      }
    }
