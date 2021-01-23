    /// <summary>
    /// This class implements a filter for the Windows.Forms message pump allowing a
    /// specific message to be forwarded to the Control specified in the constructor.
    /// Adding and removing of the filter is done automatically.
    /// </summary>
    public class MessageForwarder : NativeWindow, IMessageFilter
    {
        #region Fields
        private Control _Control;
        private Control _PreviousParent;
        private HashSet<int> _Messages;
        private bool _IsMouseOverControl;
        #endregion // Fields
        #region Constructors
        public MessageForwarder(Control control, int message)
            : this(control, new int[] { message }) { }
        public MessageForwarder(Control control, IEnumerable<int> messages)
        {
            _Control = control;
            AssignHandle(control.Handle);
            _Messages = new HashSet<int>(messages);
            _PreviousParent = control.Parent;
            _IsMouseOverControl = false;
            control.ParentChanged += new EventHandler(control_ParentChanged);
            control.MouseEnter += new EventHandler(control_MouseEnter);
            control.MouseLeave += new EventHandler(control_MouseLeave);
            control.Leave += new EventHandler(control_Leave);
            if (control.Parent != null)
                Application.AddMessageFilter(this);
        }
        #endregion // Constructors
        #region IMessageFilter members
        public bool PreFilterMessage(ref Message m)
        {
            if (_Messages.Contains(m.Msg) && _Control.CanFocus && !_Control.Focused
                && _IsMouseOverControl)
            {
                m.HWnd = _Control.Handle;
                WndProc(ref m);
                return true;
            }
            return false;
        }
        #endregion // IMessageFilter
        #region Event handlers
        void control_ParentChanged(object sender, EventArgs e)
        {
            if (_Control.Parent == null)
                Application.RemoveMessageFilter(this);
            else
            {
                if (_PreviousParent == null)
                    Application.AddMessageFilter(this);
            }
            _PreviousParent = _Control.Parent;
        }
        void control_MouseEnter(object sender, EventArgs e)
        {
            _IsMouseOverControl = true;
        }
        void control_MouseLeave(object sender, EventArgs e)
        {
            _IsMouseOverControl = false;
        }
        void control_Leave(object sender, EventArgs e)
        {
            _IsMouseOverControl = false;
        }
        #endregion // Event handlers
    }
