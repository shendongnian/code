    void CamProc_NewTargetPosition(IntPoint Center, System.Drawing.Bitmap image)
        {
            IntPtr hBitMap = image.GetHbitmap();
            BitmapSource bmaps = Imaging.CreateBitmapSourceFromHBitmap(hBitMap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bmaps.Freeze();
    
            Dispatcher.BeginInvoke((Action)(() =>
            {
                labelX.Content = String.Format("X: {0}", Center.X);
                labelY.Content = String.Format("Y: {0}", Center.Y);
                pictureBoxMain.Source = bmaps;
            }), DispatcherPriority.Render, null);
    
        }
