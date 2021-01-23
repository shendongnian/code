    class MyControl : Control, IServiceProvider
    {
         // Explicitly implement this
         object IServiceProvider.GetService(Type t)
         {
              // Call through to the protected version
              return this.GetService(t);
         }
         // Override the protected version...
         protected override object GetService(Type t)
         {
         }
    }
