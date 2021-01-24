    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            private const int WM_NCLBUTTONDOWN = 0xA1,
                                    HT_CAPTION = 0x2;
    
            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    
            [DllImport("user32.dll")]
            private static extern bool ReleaseCapture();
    
            public Form1() => InitializeComponent();
    
            private void button1_Click(object sender, EventArgs e)
            {
                Random r = new Random();
    
                Form testform = new Form()
                {
                    BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)),
                    FormBorderStyle = FormBorderStyle.None 
                };
    
                testform.MouseDown += (s, me) =>
                {
                    if (me.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(testform.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
                };
    
                testform.Controls.Add(new FlatClose());
    
                testform.Show();
            }
        }
    }
