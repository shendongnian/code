    public partial class MainWindow : Gtk.Window
    {
    	public MainWindow () : base(Gtk.WindowType.Toplevel)
    	{
    		Build ();
    	}
    
    	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    	{
    		Application.Quit ();
    		a.RetVal = true;
    	}
    	
    	protected virtual void OnWidgetEvent (object o, Gtk.WidgetEventArgs args)
    	{	
    		if (args.Event is Gdk.EventMotion && args.Event.Type==Gdk.EventType.MotionNotify)
    		{
    			Gdk.EventMotion eventMotion = (Gdk.EventMotion)args.Event; 
    			Console.WriteLine("mouse move {0} {1}", eventMotion.X, eventMotion.Y);
    		}
    		else if (args.Event is Gdk.EventKey && args.Event.Type==Gdk.EventType.KeyPress)
    		{
    			Gdk.EventKey eventKey = (Gdk.EventKey)args.Event;
    			if (eventKey.Key==Gdk.Key.Escape)
    			{
    				Console.WriteLine("mouse pointer ungrab");
    				Gtk.Grab.Remove(this);
          			Gdk.Pointer.Ungrab(Gtk.Global.CurrentEventTime);
    			}
    		}
    	}
    	
    	protected virtual void OnButton1WidgetEvent (object o, Gtk.WidgetEventArgs args)
    	{
    		if (args.Event is Gdk.EventButton && args.Event.Type==Gdk.EventType.ButtonPress)
    		{
    			Console.WriteLine("mouse pointer grab");
    			Gdk.Pointer.Grab(this.GdkWindow, true,
    		        Gdk.EventMask.ButtonPressMask | Gdk.EventMask.ButtonReleaseMask | Gdk.EventMask.PointerMotionMask | Gdk.EventMask.EnterNotifyMask | Gdk.EventMask.LeaveNotifyMask, 
                    null, null, Gtk.Global.CurrentEventTime); 
    			Gtk.Grab.Add (this);
    		}
    	}
    }
 
