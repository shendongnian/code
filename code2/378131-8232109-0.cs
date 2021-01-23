    private Capture _capture;
    
    public YOUR_PROJECT()
    {
        InitializeComponent();
        try
        {
            _capture = new Capture();
        }
        catch (NullReferenceException excpt)
        {
            MessageBox.Show(excpt.Message);
        }
        if (_capture != null)
        {
            Application.Idle += ProcessFrame;
        }
    }
    
    
    private void ProcessFrame(object sender, EventArgs arg)
    {
        Image<Bgr, Byte> frame = _capture.QueryFrame();
        Picturebox1.Image = frame.ToBitmap(); //Display image in standard Picture Box
    }
