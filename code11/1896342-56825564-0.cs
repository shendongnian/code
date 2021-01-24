        bool _streaming;
        VideoCapture _capture;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _streaming = false;
            _capture = new VideoCapture();
            
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (_streaming == false)
            {
                //Start streaming
                Application.Idle += streaming;
                button2.Text = "Stop Streaming";
            }
            else
            {
                Application.Idle -= streaming;
                button2.Text = "Start Streaming";
            }
            _streaming = !_streaming;
        }
        private void streaming(object sender, EventArgs e)
        {
            
            var img = _capture.QueryFrame();
            imageBox2.Image = img;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            imageBox1.Image = imageBox2.Image;
        }
