    public delegate void ViewEventHandler(MvcMessage message);
    
    public interface IView : IViewPage, IWin32Window
    {
        event ViewEventHandler ViewEvent;
        ...
    }
