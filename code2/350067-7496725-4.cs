    Image<Bgr, Byte> frame;
    using (Capture capture = new Capture())
    {
        frame = capture1.QueryFrame().Copy(); //You must copy else frame will be disposed off
    }
    Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>();
    Image<Gray, Byte> smallGrayFrame = grayFrame.PyrDown();
    Image<Gray, Byte> smoothedGrayFrame = smallGrayFrame.PyrUp();
    Image<Gray, Byte> cannyFrame = smoothedGrayFrame.Canny(new Gray(100), new Gray(60));
    grayscaleImageBox.Image = grayFrame;
    smoothedGrayscaleImageBox.Image = smoothedGrayFrame;
    cannyImageBox.Image = cannyFrame;
