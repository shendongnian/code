    private void detectFace()
    {
        CascadeClassifier face = new CascadeClassifier(facePath);
        Image<Bgr, Byte> currentframe = null;
        Image<Gray, byte> grayFrame = null;
        Capture grabber;
        grabber = new Capture(videoDevice);
        var dstMat = new Mat();
        var frame = grabber.QueryFrame();
        CvInvoke.Resize(frame, dstMat, new Size(500, 320), interpolation: Emgu.CV.CvEnum.Inter.Cubic);
        currentframe = dstMat.ToImage<Bgr, byte>();
        if (currentframe != null)
        {
            grayFrame = currentframe.Convert<Gray, Byte>();
            Rectangle[] faceDetected = face.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty, Size.Empty);
            foreach (Rectangle faceFound in faceDetected)
            {
                currentframe.Draw(faceFound, new Bgr(Color.Red), 2);
            }
            var oldImage = panAndZoomPictureBox1.Image;
            panAndZoomPictureBox1.Image = currentframe.ToBitmap();
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
            currentframe.Dispose();
            grayFrame.Dispose();
        }
        face.Dispose();
        grabber.Dispose();
        dstMat.Dispose();
        frame.Dispose();
    }
