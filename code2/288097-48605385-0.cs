    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Accord.Video.FFMPEG;
    
    
    namespace TimerScratchPad
    {
        public partial class Form1 : Form
        {
            VideoFileWriter writer = new VideoFileWriter();
            int second = 0;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                writer.VideoCodec = VideoCodec.H264;
                writer.Width = Screen.PrimaryScreen.Bounds.Width;
                writer.Height = Screen.PrimaryScreen.Bounds.Height;
                writer.BitRate = 1000000;
                writer.Open("D:/DemoVideo.mp4");
    
                RecordTimer.Interval = 40;
                RecordTimer.Start();
               
            }
    
            private void RecordTimer_Tick(object sender, EventArgs e)
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    writer.WriteVideoFrame(bitmap);
                }
    
                textBox1.Text = RecordTimer.ToString();
                second ++;
                if(second > 1500)
                {
                    RecordTimer.Stop();
                    RecordTimer.Dispose();
                    writer.Close();
                    writer.Dispose();
                }
            }
        }
    }
