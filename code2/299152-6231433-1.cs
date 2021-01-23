    // Association 
    public class ThirdPartyPersistentSet
    {
        private PersistentObject _object;
        public ThirdPartyPersistentSet(PersistentObject obj)
        {
            _object = obj;
        }
    }
    // Dependency
    public class ThirdPartyPersistentSet
    {
        public ThirdPartyPersistentSet(PersistentObject obj)
        {
            obj.GetSomething(); // Do something with obj,
            // but do not store it to a local variable.
            // You only 'use' it and ThirdPartyPersistentSet
            // does not 'know' about it.
        }
    }
