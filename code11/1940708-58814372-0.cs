    using Basler.Pylon; // You'll need to add a reference to Basler.Pylon.DLL as well
    var cam = new Camera();
    cam.Open();
    Console.WriteLine("Using camera {0}.", cam.CameraInfo[CameraInfoKey.SerialNumber]);
    cam.Parameters[PLCamera.ExposureTimeAbs].SetValue(1000, FloatValueCorrection.ClipToRange);
    cam.StreamGrabber.ImageGrabbed += OnImageGrabbed1;
    cam.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
    private void OnImageGrabbed1(object sender, ImageGrabbedEventArgs e)
    {
        IGrabResult grabResult = e.GrabResult;
        if (grabResult.GrabSucceeded)
        {
            using (Bitmap bm = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb))
            {
                BitmapData bmpData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, bm.PixelFormat);
                converter.OutputPixelFormat = PixelType.BGRA8packed;
                IntPtr ptrBmp = bmpData.Scan0;
                converter.Convert(ptrBmp, bmpData.Stride * bm.Height, grabResult);
                bm.UnlockBits(bmpData);
                using (Image<Bgr, byte> imageCV = new Image<Bgr, byte>(bm))
                {
                    // Example Emgu CV function
                    double mean = CvInvoke.Mean(imageCV.Mat).V0;
                }
            }
        }
        else
        {
            LogMessage($"Camera 1 error: {grabResult.ErrorCode} {grabResult.ErrorDescription}");
        }
    }
