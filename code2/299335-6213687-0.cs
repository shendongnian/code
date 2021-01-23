     public class MyTreeView : TreeView
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203) { m.Result = IntPtr.Zero; } //Makes the control ignore double licks
            else base.WndProc(ref m);
        }              
    };
