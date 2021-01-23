    public abstract class BaseViewModel<T> : NotificationObject, INavigationAware
        where T : Entity
    {
        public T MyEntity;
    
        public SomeMethod()
        {
            MyEntity.SomeEntityProperty = SomeValue;
        }
    }
