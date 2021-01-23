    private static readonly Dictionary<Type, Action<Control>> _handlers
               = new Dictionary<Type, Action<Control>>();
    // Handle.. methods
    private static void HandleButton(Button button) { ... }
    private static void HandleListbox(Listbox listbox) { ... }
    private static void RegisterHandler<T>(Action<T> handler)
          where T: Control
    {
        _handlers.Add(typeof(T), o => handler((T)o));
    }
    // invoke this method in static constructor
    private static void InitializeHandlers()
    {
        RegisterHandler<Button>(HandleButton);
        RegisterHandler<Listbox>(HandleListbox);
    }
    // finally usage:
    internal static void DoSomething(Control control)
    {
        var handler = _handlers[control.GetType()];
        handler(control);
    }
