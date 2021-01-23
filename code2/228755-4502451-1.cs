    public static class ComponentFactory<T>
    {
        public static IComponent<T> CreateComponent()
        {
            Type generic = Type.GetType("MyCompany.Components.ConcreteComponent1`1");
            Type concrete = generic.MakeGenericType(typeof(T));
            var objectHandle = Activator.CreateInstance(
               concrete,
               BindingFlags.NonPublic | BindingFlags.Instance,
               null,
               null, //here can come ctor params
               null); 
            return objectHandle as IComponent<T>;
        }
    }
