    using (CvCapture cap = CvCapture.FromCamera(CaptureDevice.Any, 1))
    {
        while (true)
        {
            Bitmap bm = BitmapConverter.ToBitmap(cap.QueryFrame());
            bm.SetResolution(pctCvWindow.Width, pctCvWindow.Height);
            pctCvWindow.Image = bm;
        }
    }
}
