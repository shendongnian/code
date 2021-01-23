    public partial class frmWait : Form
    {
        public frmWait()
        {
            InitializeComponent();
        }
        bool _isMoving = false;
        int _moveStart_x = 0;
        int _moveStart_y = 0;
        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            if (barProgress.Value == barProgress.Maximum)
                barProgress.Value = barProgress.Minimum;
            else
                barProgress.Value += 1;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            PleaseWait.Abort();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams p = base.CreateParams;
                p.ClassStyle += 0x20000;
                p.ExStyle += 0x8000000;
                return p;
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 132;
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if (m.Result.ToInt32() == 1)
                        m.Result = new IntPtr(2);
                    break;
            }
        }
        private void panelEx1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMoving = true;
                _moveStart_x = e.X;
                _moveStart_y = e.Y;
            }
        }
        private void panelEx1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMoving = false;
        }
        private void pnlContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMoving)
                this.Location = new Point(Location.X + e.X - _moveStart_x, Location.Y + e.Y - _moveStart_y);
        }
    }
    public class PleaseWait
    {
        #region Static Operations
        private static Boolean _isAborted = false;
        private static Boolean _isVisible = false;
        private static frmWait _waitForm;
        private static String _waitingState = "";
        private static Boolean _autoClose = false;
        private static Boolean _cancelable = false;
        private static System.Threading.Thread _waiterThred;
        public delegate void CancelButtonPressed();
        public static event CancelButtonPressed OnCancel;
        public static Boolean AutoClose
        {
            get { return PleaseWait._autoClose; }
            set { PleaseWait._autoClose = value; }
        }
        public static string WaitingState
        {
            get { return PleaseWait._waitingState; }
            set { PleaseWait._waitingState = value; }
        }
        public static bool IsVisible
        {
            get { return _isVisible; }
            internal set { _isVisible = value; }
        }
        public static void ShowPleaseWait()
        {
            ShowPleaseWait("", _autoClose, false);
        }
        public static void ShowPleaseWait(string waitingState)
        {
            ShowPleaseWait(waitingState, _autoClose, false);
        }
        public static void ShowPleaseWait(bool autoClose)
        {
            ShowPleaseWait("", autoClose, false);
        }
        public static void ShowPleaseWait(string waitingState, bool autoClose, bool cancelable)
        {
            if (_waiterThred != null)
            {
                if (_isVisible)
                {
                    // the please wait it woking, just continue and apply the changes
                    _waitingState = waitingState;
                    _autoClose = autoClose;
                    _cancelable = cancelable;
                    return;
                }
                else
                {
                    _waiterThred.Abort();
                    _waiterThred = null;
                }
            }
            _waitingState = waitingState;
            _autoClose = autoClose;
            _cancelable = cancelable;
            _isAborted = false;
            _isVisible = false;
            if (_autoClose)
                Application.Idle += new EventHandler(Application_Idle);
            _waiterThred = new System.Threading.Thread(DisplayWaitingForm);
            _waiterThred.IsBackground = true;
            _waiterThred.Name = "Please Wait....";
            _waiterThred.Start();
            Application.DoEvents();
        }
        public static void Abort()
        {
            _isAborted = true;
        }
        private static void Application_Idle(object sender, EventArgs e)
        {
            if (_autoClose)
                _isAborted = true;
        }
        private static void DisplayWaitingForm()
        {
            if (_waitForm != null)
            {
                if (!_waitForm.IsDisposed)
                    _waitForm.Dispose();
                _waitForm = null;
                _isVisible = false;
            }
            try
            {
                if (_isAborted)
                    return;
                _waitForm = new frmWait();
                if (_cancelable)
                {
                    _waitForm.btnCancel.Enabled = true;
                    _waitForm.btnCancel.Click += new EventHandler(btnCancel_Click);
                }
                try
                {
                    _isVisible = true;
                    _waitForm.Show();
                    _waitForm.Focus();
                    while (!_isAborted)
                    {
                        System.Threading.Thread.Sleep(15);
                        _waitForm.lblMessage.Text = _waitingState;
                        Application.DoEvents();
                        _waitForm.lblMessage.Text = _waitingState;
                    }
                    _isVisible = false;
                }
                finally
                {
                    FreeWaitingForm();
                }
            }
            finally
            {
                _isVisible = false;
            }
        }
        static void btnCancel_Click(object sender, EventArgs e)
        {
            if (_waitForm.InvokeRequired)
            {
                _waitForm.BeginInvoke(new EventHandler(btnCancel_Click), new object[] { e });
            }
            else
            {
                if (OnCancel != null)
                    OnCancel.Invoke();
            }
        }
        private static void FreeWaitingForm()
        {
            _waitingState = "";
            _isVisible = false;
            if (_waitForm == null)
            {
                return;
            }
            _waitForm.Hide();
            if (!_waitForm.IsDisposed)
                _waitForm.Dispose();
            _waitForm = null;
        }
        #endregion
    }
