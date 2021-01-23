    public Task<string> GetRepsonseAsync()
    {
         return Task.Factory.StartNew( () =>
         {
              return this.GetResponse(); // calls the synchronous version
         });
    }
