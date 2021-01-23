    public static class ResourceItemRepository {
      public static ResourceItem GetById(int id) {
        using (var db = CreateDataContext()) {
          // Code goes here... 
        }
      }
      public static List<ResourceItem> GetInCateogry(int catId) {
        using (var db = CreateDataContext()) {
          // Code goes here... 
        }
      }
      public static ResourceItem.Type GetType(int id) {
        using (var db = CreateDataContext()) {
          // Code goes here... 
        }
      }
      private static TestDataContext CreateDataContext() {
        return DataContextFactory.Create<TestDataContext>();
      }
    }
