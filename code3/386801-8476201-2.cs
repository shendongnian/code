    Timer My_Time = new Timer();
    int FPS = 30;
    List<Image<Bgr,Byte>> image_array = new List<Image<Bgr,Byte>>();
    Capture _capture;    
    public Form1()
    {
        InitializeComponent();
    
        //Frame Rate
        My_Timer.Interval = 1000 / FPS;
        My_Timer.Tick += new EventHandler(My_Timer_Tick);
        My_Timer.Start()
        _capture = new Capture("test.avi");   
    }
    
    private void My_Timer_Tick(object sender, EventArgs e)
    {
        Image<Bgr, Byte> frame = _capture.QueryFrame();
        if (frame != null)
        {
            imageBox.Image = _capture.QueryFrame();
            image_array.Add(_capture.QueryFrame().Copy());
        }
        else
        {
             My_Timer.Stop();
        {
    }
