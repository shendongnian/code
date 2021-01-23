    // These attributes may be optional, depending on the project configuration.
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class EventListener
    {
        [DispId(0)]
        public void NameDoesNotMatter(IDOMEvent evt) { ... }
    }
