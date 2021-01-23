    public class ReadOnlyListBox : ListBox
    {
        private bool _readOnly = false;
        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }
        protected override void DefWndProc(ref Message m)
        {
            // If ReadOnly is set to true, then block any messages 
            // to the selection area from the mouse or keyboard. 
            // Let all other messages pass through to the 
            // Windows default implementation of DefWndProc.
            if (!_readOnly || ((m.Msg <= 0x0200 || m.Msg >= 0x020E)
            && (m.Msg <= 0x0100 || m.Msg >= 0x0109)
            && m.Msg != 0x2111
            && m.Msg != 0x87))
            {
                base.DefWndProc(ref m);
            }
        }
    }
