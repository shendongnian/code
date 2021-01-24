    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private MyFilter mf;
        private void Form1_Load(object sender, EventArgs e)
        {
            button5.Visible = false;
            mf = new MyFilter();
            mf.MouseMoved += Mf_MouseMoved;
            mf.ThreeSecondWithoutMouseMove += Mf_ThreeSecondWithoutMouseMove;
            Application.AddMessageFilter(mf);
        }
        private void Mf_MouseMoved()
        {
            button5.Visible = true;
        }
        private void Mf_ThreeSecondWithoutMouseMove()
        {
            button5.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked me!");
        }
    }
    public class MyFilter : IMessageFilter
    {
        public delegate void dlgMouseMoved();
        public delegate void dlgThreeSeconds();
        public event dlgMouseMoved MouseMoved;
        public event dlgThreeSeconds ThreeSecondWithoutMouseMove;
        private Point lastPoint;
        private const int WM_MOUSEMOVE = 0x200;
        private System.Windows.Forms.Timer tmr;
        
        public MyFilter()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Enabled = false;
            tmr.Interval = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;
            tmr.Tick += Tmr_Tick;
        }
        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MOUSEMOVE: // you WILL get phantom WM_MOUSEMOVE messages, when the mouse has NOT moved!
                    Point curPoint = Cursor.Position;
                    if (!curPoint.Equals(lastPoint)) 
                    {
                        lastPoint = curPoint;
                        if (MouseMoved != null)
                        {
                            MouseMoved();
                        }
                        tmr.Stop();
                        tmr.Start();
                    }
                    break;
            }
            return false; // handle messages normally
        }
        private void Tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            if (ThreeSecondWithoutMouseMove != null)
            {
                ThreeSecondWithoutMouseMove();
            }
        }
    }
