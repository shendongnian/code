    private void webcam_ImageCaptured(object source, WebcamEventArgs e)
    {
        using( Bitmap b = e.WebCamImage )
        {
             _frameImage.Source = LoadBitmap((System.Drawing.Bitmap)e.WebCamImage);   
        }
    }
