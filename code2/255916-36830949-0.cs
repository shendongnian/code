    public class SomeTypeFactory
    {
      // ... take IUnityContainer as a dependency and save it
      IDependencyDisposer< SomeType > Create()
      {
        return this.unity.ResolveForDisposal< SomeType >();
      }
    }
    public class BusinessClass
    {
      // ... take SomeTypeFactory as a dependency and save it
      public void AfunctionThatCreatesSomeTypeDynamically()
      {
        using ( var wrapper = this.someTypeFactory.Create() )
        {
          SomeType subject = wrapper.Subject;
          // ... do stuff
        }
      }
    }
