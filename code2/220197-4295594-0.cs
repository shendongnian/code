    public partial class UserControl1 : UserControl
    {
        public UserControl1() {
            InitializeComponent();
        }
    
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
    
            // draw image here
        }
    
        public ToolTip ToolTip { get; set; }
    
        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
    
            if (this.ToolTip != null)
                this.ToolTip.Hide(this);
        }
    
        protected override void OnMouseHover(EventArgs e) {
            base.OnMouseHover(e);
    
            if (this.ToolTip == null)
                return;
    
            Point pt = this.PointToClient(Cursor.Position);
            String msg = this.CalculateMsgAt(pt);
            if (String.IsNullOrEmpty(msg))
                return;
    
            pt.Y += 20;
            this.ToolTip.Show(msg, this, pt);
        }
    
        private string CalculateMsgAt(Point pt) {
            // Calculate the message that should be shown 
            // when the mouse is at thegiven point
            return "This is a tooltip";
        }
    }
