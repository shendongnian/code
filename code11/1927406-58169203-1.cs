    public sealed class MyClass
    {
      private MyData asyncData;
      private MyClass() { ... }
    
      private async Task<MyClass> InitializeAsync()
      {
        asyncData = await GetDataAsync();
        return this;
      }
    
      public static Task<MyClass> CreateAsync()
      {
        var ret = new MyClass();
        return ret.InitializeAsync();
      }
    }
    
    public static async Task UseMyClassAsync()
    {
      MyClass instance = await MyClass.CreateAsync();
      ...
    }
