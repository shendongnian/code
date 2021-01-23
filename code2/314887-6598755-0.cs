    [ComVisibleAttribute(true)]
    [ClassInterfaceAttribute(ClassInterfaceType.AutoDispatch)]
    public class Element : Component, IDropTarget, ISynchronizeInvoke, IWin32Window, 
	IBindableComponent, IComponent, IDisposable
    {
        private Control _control;
    }
