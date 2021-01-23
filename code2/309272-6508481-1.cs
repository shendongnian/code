    instance = Activator.CreateInstance(type);
    var setModel = type.GetMethod("SetModel", BindingFlags.Public | BindingFlags.Instance);
    var render = type.GetMethod("Render", BindingFlags.Public | BindingFlags.Instance);
    setModel.Invoke(instance, new object[] { new ProxyDynamicObject(model) });
    render.Invoke(instance, null);
