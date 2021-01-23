    [Serializable]
    class MyCustomAttribute : LocationLevelAspect
    {
      string propertyName;
     
      public override void  CompileTimeInitialize( LocationInfo targetLocation,
                                                   AspectInfo aspectInfo )
      {
          this.propertyName = targetLocation.PropertyName;
      }
    }  
