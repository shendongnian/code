        public partial class Form1 : Form
    {
        public Bitmap newBitmap;
        public VideoCaptureDevice cam = null;
        public FilterInfoCollection usbCams;
        AVIReader reader = new AVIReader();
        AVIWriter writer = new AVIWriter("wmv3");
        AVIFileVideoSource source = new AVIFileVideoSource("test.avi");
        FileVideoSource normSource = new FileVideoSource("test.avi");
        VideoSourcePlayer player = new VideoSourcePlayer();
        public Form1()
        {
            InitializeComponent();
        }
        public void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            writer.AddFrame(image);
            pictureBox1.Image = image;
        }
        public void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            newBitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = newBitmap;
        }
        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            videoSourcePlayer1.VideoSource = normSource;
            videoSourcePlayer1.GetCurrentVideoFrame();
            videoSourcePlayer1.DrawToBitmap(newBitmap,
                new Rectangle(0, 0, image.Width, image.Height));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            source.NewFrame += new NewFrameEventHandler(video_NewFrame);
            source.Start();
            videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer_NewFrame);
            videoSourcePlayer1.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (source.IsRunning == true)
            {
                source.Stop();
                videoSourcePlayer1.Stop();
            }
            if (cam != null)
            {
                cam.Stop();
                writer.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            usbCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cam = new VideoCaptureDevice(usbCams[0].MonikerString);
            cam.DesiredFrameSize = new Size(320, 240);
            writer.Open("test.avi", 320, 240);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.DesiredFrameRate = 25;
            cam.Start();
        }
    }
