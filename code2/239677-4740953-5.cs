    private static Dictionary<Type, IDrawInstructions> _registry = new Dictionary<Type, IDrawInstructions>();
    public static void Register<T>(IDrawInstructions instructions) where T: Shape
    {
        var type = typeof (T);
        if(_registry.ContainsKey(type))
            _registry[type] = instructions;
        else
        {
            _registry.Add(type, instructions);
        }
    }
    public static IDrawInstructions Lookup(Shape shape)
    {
        var type = shape.GetType();
        if (!_registry.ContainsKey(type)) return null;
        return _registry[type];
    }
