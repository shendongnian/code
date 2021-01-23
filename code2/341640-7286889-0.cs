    namespace EomApp1.UI
    {
        public class AppFormBase : Form
        {
            public AppFormBase()
            {
                InitializeComponent();
                this.ControlAdded += new ControlEventHandler(FormBase_ControlAdded);
                this.Deactivate += new EventHandler(AppFormBase_Deactivate);
                this.FormClosing += new FormClosingEventHandler(AppFormBase_FormClosing);
            }
    
            protected override void OnLoad(EventArgs e)
            {
                if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
                {
                    this.MouseDown += new MouseEventHandler(AppFormBase_MouseDown);
                    this.MouseMove += new MouseEventHandler(AppFormBase_MouseMove);
                    this.MouseUp += new MouseEventHandler(AppFormBase_MouseUp);
                    this.MovesWithMouseDown = true;
                }
    
                base.OnLoad(e);
            }
    
            void AppFormBase_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                {
                    return;
                }
                downPoint = new Point(e.X, e.Y);
            }
    
            void AppFormBase_MouseMove(object sender, MouseEventArgs e)
            {
                if (downPoint == Point.Empty)
                {
                    return;
                }
                Point location = new Point(
                    this.Left + e.X - downPoint.X,
                    this.Top + e.Y - downPoint.Y);
                this.Location = location;
            }
    
            void AppFormBase_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                {
                    return;
                }
                downPoint = Point.Empty;
            }
    
            public bool MovesWithMouseDown { get; set; }
    
            public Point downPoint = Point.Empty;
        }
    }
