    public static class ComponentFactory<T>
    {
        public static IComponent<T> CreateComponent()
        {
            Type generic = Type.GetType("MyCompany.Components.ConcreteComponent1`1");
            Type concrete = generic.MakeGenericType(typeof(T));
            var objectHandle = Activator.CreateInstance(concrete); 
            return objectHandle as IComponent<T>;
        }
    }
