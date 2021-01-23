    public class MyListView : ListView
    {
        public event EventHandler<EventArgs> Scrolled;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int wm_vscroll = 0x115;
            if (m.Msg == wm_vscroll && Scrolled != null)
            {
                Scrolled(this, new EventArgs());
            }
        }
    }
