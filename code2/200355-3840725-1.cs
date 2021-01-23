    class Example : IServiceProvider {
      public object GetServiceWrongName(t as Type) {
        ..
      }
      
      object IServiceProvider.GetService(t as Type) {
        return GetServiceWrongName(t);
      }
    
    }
