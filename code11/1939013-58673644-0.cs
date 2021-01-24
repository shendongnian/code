    public partial class Form1 : Form
    {
       [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
       public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    
       private const int MouseLeftDown = 0x02;
       private const int MouseLeftUp = 0x04;
    
       private readonly Timer _timer = new Timer();
    
       public Form1()
       {
          InitializeComponent();
    
          _timer.Interval = 1000;
          _timer.Tick += (s, a) => mouse_event(MouseLeftDown | MouseLeftUp, (uint)MousePosition.X, (uint)MousePosition.Y, 0, 0);
          _timer.Enabled = true;
    
          _textBox.Click += (s, a) => _textBox.AppendText($"Clicked at {PointToClient(MousePosition)}\n");
       }
    }
