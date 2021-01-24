    [Register ("App")]
    public class App : NSApplication
    {
        public App (System.IntPtr p) : base (p)
        {
        }
        public override void SendEvent (NSEvent theEvent)
        {
            base.SendEvent (theEvent);
        }
    }
