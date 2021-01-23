    List<Image<Bgr,Byte>> image_array = new List<Image<Bgr,Byte>>();
    Capture _capture;
        
    public Form1()
    {
        InitializeComponent();
    
        //Frame Rate
        _capture = new Capture("test.avi");   
        Application.Idle += ProcessFrame;
    }
    
    private void ProcessFrame(object sender, EventArgs arg)
    {
        Image<Bgr, Byte> frame = _capture.QueryFrame();
        if (frame != null)
        {
            image_array.Add(frame.Copy());
        }
        else
        {
            Application.Idle -= ProcessFrame;// treat as end of file
        }
        
    }
