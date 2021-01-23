    // Declaration
    class SomeMechanism
    {
        public static T Get<T>(Func<T> getter);
    }
    
    // Usage
    Car car1;
    Car car2;
    Car car = SomeMechanism.Get(() => car1);
