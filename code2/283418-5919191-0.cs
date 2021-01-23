    public partial class DragForm : Form
    {
        // Offset from upper left of form where mouse grabbed
        private Size? _mouseGrabOffset;
        public DragForm()
        {
            InitializeComponent();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if( e.Button == System.Windows.Forms.MouseButtons.Right )
                _mouseGrabOffset = new Size(e.Location);
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _mouseGrabOffset = null;
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_mouseGrabOffset.HasValue)
            {
                this.Location = Cursor.Position - _mouseGrabOffset.Value;
            }
            base.OnMouseMove(e);
        }
    }
