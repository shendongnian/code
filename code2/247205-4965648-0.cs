    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var mcb = new MyComboBox() { Left = 6, Top = 6 };
            this.Controls.Add(mcb);
            for (int i = 0; i < 20; i++)
            {
                mcb.AddItem("Item " + i.ToString() );
            }
        }
    }
    public class MyComboBox : ComboBox
    {
        private MyDropDown _dropDown;
        public MyComboBox()
        {
            _dropDown = new MyDropDown() { Width = 200, Height = 200 };
        }
        public void AddItem(string text)
        {
            _dropDown.AddControl(new CheckBox() { Text = text });
        }
        public void ShowDropDown()
        {
            if (_dropDown != null)
            {
                _dropDown.Show(this);
            }
        }
        public void CloseDropDown()
        {
            if (_dropDown != null)
            {
                _dropDown.Close();
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WndUI.WM_REFLECT + WndUI.WM_COMMAND)
            {
                if (WndUI.HIWORD(m.WParam) == WndUI.CBN_DROPDOWN)
                {
                    ShowDropDown();
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
    [ToolboxItem(false)]
    public class MyDropDown : ToolStripDropDownMenu
    {
        public MyDropDown()
        {
            this.ShowImageMargin = this.ShowCheckMargin = false;
            this.AutoSize = false;
            this.DoubleBuffered = true;
            this.Padding = Margin = Padding.Empty;
        }
        public int AddControl(Control control)
        {
            var host = new ToolStripControlHost(control);
            host.Padding = host.Margin = Padding.Empty;
            host.BackColor = Color.Transparent;
            return this.Items.Add(host);
        }
        public void Show(Control control)
        {
            Rectangle area = control.ClientRectangle;
            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
            this.Focus();
        }
    }
    public static class WndUI
    {
        public const int
            WM_USER = 0x0400,
            WM_REFLECT = WM_USER + 0x1C00,
            WM_COMMAND = 0x0111,
            CBN_DROPDOWN = 7;
        public static int HIWORD(IntPtr n)
        {
            return HIWORD(unchecked((int)(long)n));
        }
        public static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }
    }
