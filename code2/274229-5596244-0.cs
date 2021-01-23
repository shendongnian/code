    public void InitializeWebCam(ref System.Windows.Forms.PictureBox ImageControl)
    {
        webcam = new WebCamCapture();
        webcam.FrameNumber = ((ulong)(0ul));
        webcam.TimeToCapture_milliseconds = FrameNumber;
        webcam.ImageCaptured += new WebCamCapture.WebCamEventHandler(webcam_ImageCaptured);
        _FrameImage = ImageControl;
    }
    void webcam_ImageCaptured(object source, WebcamEventArgs e)
    {
        _FrameImage.Image = e.WebCamImage;
    }
