    interface IMyInterfaceFactory
    {
       IMyInterface Resolve(string parameter);
    }
    class DecoratorFactory : IMyInterfaceFactory
    {
       IMyInterfaceFactory parent;
       Func<IMyInterface, string, IMyInterface> resolver;
 
       public DecoratorFactory(
          IMyInterfaceFactory parent, 
          Func<IMyInterface, string, IMyInterface> resolver)
       {
          this.parent = parent;
          this.resolver= resolver;
       }
       public IMyInterface Resolve(string parameter)
       {
          var decoratee = parent.Resolve(parameter);
          return resolver(decoratee, parameter);
       }
    }
