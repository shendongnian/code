    abstract class AbstractFactory<T> : IFactory {
      public Type CreatedType { get { return typeof(T); }
      public virtual object Create() {
        return innerCreate();
      }
      protected abstract override T innerCreate();
    }
