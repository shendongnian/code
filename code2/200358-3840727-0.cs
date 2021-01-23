    class MyControl : Control, IServiceProvider
    {
         object IServiceProvider.GetService(Type t)
         {
             ...
         }
    }
