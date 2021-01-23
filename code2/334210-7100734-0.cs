    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [Guid("eventGuid")]
    [CLSCompliant(false)]
    public interface IEvent
    {       
       [DispId(123)]
       void control_connected(int status, string description);
    }
    public class EventSink:IEvent
    {
       object control;
       public EventSink (object control)
       {
            this.control=control;
       }  
       public event EventHandler<ControlConnectedEventArgs> ControlConnected;
       void control_connected(int status, string description);
       {
           EventHandler<ControlConnectedEventArgs> temp=this.ControlConnected;
           if(temp!=null)
               temp(this.control, new ControlConnectedEventArgs(status,description));
       }
    }
