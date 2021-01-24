    class PenFilter : IMessageFilter
    {
        private const int PEN = 0x0711;
        private readonly Form parent;
        public PenFilter(Form parent)
        {
            this.parent = parent;
        }
        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            Control targetControl = Control.FromChildHandle(m.HWnd);
            if (targetControl != null && (targetControl == parent || parent == targetControl.FindForm()))
            {
                // execute your function
            }
            return false;
        }
    }
