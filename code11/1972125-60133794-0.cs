powershell
Add-Type @'
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
namespace UniversalSandbox
{
    public partial class Form1 : Form
    {
        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_PREV_TRACK = 0xB1;
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
        public Form1()
        {
        
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        
        private void InitializeComponent(){
        var button1 = new Button();
        var button2 = new Button();
        var button3 = new Button();
        button1.Text = "Play";
        button1.Location = new Point(20, 100);
        button1.Click += new EventHandler(button1_Click);
        button2.Text = "Prev";
        button2.Location = new Point(110, 100);
        button2.Click += new EventHandler(button2_Click);
        button3.Text = "Next";
        button3.Location = new Point(200, 100);
        button3.Click += new EventHandler(button3_Click);
         this.Controls.Add(button1);
         this.Controls.Add(button2);
         this.Controls.Add(button3);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }
    }
}
'@  -ReferencedAssemblies System.Windows.Forms, System.Drawing  
$player = [UniversalSandbox.Form1]::new()
$player.ShowDialog()
