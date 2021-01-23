    public interface IChildFactory {
      IChild Create(IDependency dependency);
    }
    public class ParentClass
    {
      private readonly IChildClass _child;
      public ParentClass(IChildFactory childFactory, IDependency dependency)
      {
        _child = childFactory.Create(dependency);
      }
    }
    class ChildFactory : IChildFactory 
    {
      IChildClass Create(IDependency dependency)
      {
        return new ChildClass(dependency);
      }
    }
