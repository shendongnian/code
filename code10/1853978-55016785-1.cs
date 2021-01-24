    private bool recordingOn = false;
    private static object _lock = new Object();
    
    private void ConnectCameras_Button_Click(object sender, EventArgs e)
    {
        if (!captureInProgress) //Start cameras streaming
        {
            camera1Capture.ImageGrabbed += ProcessFrame;
            camera1Capture.Start();
        }
        else //Stop cameras streaming
        {
            camera1Capture.Stop();
            imageBox1.Image = null;
            camera1Capture.ImageGrabbed -= ProcessFrame;
        }
        captureInProgress = !captureInProgress;
    }
    
    private void ProcessFrame(object sender, EventArgs arg)
    {
        camera1Capture.Retrieve(frame1);
        imageBox1.Image = frame1;
        lock (_lock)
        {
        if (recordingOn)
        {
            try
            {
                writer1.Write(frame1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
    }
    
    private void Stop_Button_Click(object sender, EventArgs e)
    {
        // Doing other stuff...
        lock (_lock)
        {
          recordingOn = false;
          writer1.Dispose();   
        }
           
    }
