    Image<Bgr, Byte> frame;
    using (Capture capture1 = new Capture())
    {
        frame = capture1.QueryFrame().Resize(0.5, Emgu.CV.CvEnum.INTER.CV_INTER_AREA).Copy();
        captureImageBox.Image = frame;
    }
    
    using (Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>())
    {
        grayscaleImageBox.Image = grayFrame;
        using (Image<Gray, Byte> smallGrayFrame = grayFrame.PyrDown())
        {
            using (Image<Gray, Byte> smoothedGrayFrame = smallGrayFrame.PyrUp())
            {
                smoothedGrayscaleImageBox.Image = smoothedGrayFrame;
                using (Image<Gray, Byte> cannyFrame = smoothedGrayFrame.Canny(new Gray(100), new Gray(60)))
                {
                    cannyImageBox.Image = cannyFrame;
                }
            }
        }
    }
