    // These attributes may be optional, depending on the project configuration.
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class EventListener
    {
        [DispId(0)]
        // The "target" parameter is an implementation detail.
        public void NameDoesNotMatter(object target, IDOMEvent evt) { ... }
    }
