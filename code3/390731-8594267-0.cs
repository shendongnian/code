    public class Bus {
      readonly ILifetimeScope _OwnScope;
      // Autofac always provides ILifetimeScope that owns a component as a service to the component
      // so it can be used as a dependency
      public Bus(ILifetimeScope ownScope) {
        _OwnScope = ownScope;
      }
      void Send<T>(T message) {
        _OwnScope.Resolve<IHandler<T>>.Handle(message);
      }
    }
