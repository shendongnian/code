    class ComponentManager
    {
        public Dictionary<Type, Component> Components { get; private set; }
        public ComponentManager()
        {
            Components = new Dictionary<Type, Component>();
        }
    }
