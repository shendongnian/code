    // Instead of having WebCam as member variable, have WemCamCapture
    WebCamCapture webCam;
    // Change the mainWinForm_Load function
    private void mainWinForm_Load(object sender, EventArgs e)
    {
        webCam = new WebCamCapture();
        webCam.FrameNumber = ((ulong)(0ul));
        webCam.TimeToCapture_milliseconds = 30;
        webCam.ImageCaptured += webcam_ImageCaptured;
    }
    // Add the webcam Image Captured handler to the main form
    private void webcam_ImageCaptured(object source, WebcamEventArgs e)
    {
        Image imageCaptured = e.WebCamImage;
        // You can now stop the camera if you only want 1 image
        // webCam.Stop();
        // Add code here to save image to disk
    }
    // Adjust the code in bntStart_Click
    // (yes I know there is a type there, but to make code lineup I am not fixing it)
    private void bntStart_Click(object sender, Event Args e)
    {
        webCam.Start(0);
    }
   
    
