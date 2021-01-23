        private Task _runningTask;
        // only call this method from the UI!
        private void UpdateBitmap()
        {
            int brightness = bright_tbr.Value; 
            int contrast = contrast_tbr.Value;
            // only when not yet running
            if (_runningTask == null)
            {
                var ui = TaskScheduler.FromCurrentSynchronizationContext();
                _runningTask = Task.Factory.StartNew<Bitmap>(() =>
                {
                    // prepare
                    create_pixmap(brightness, contrast, 0, 0, 255, 255);
                    Bitmap bmp1 = new Bitmap(bmp);
                    BitmapData data1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    MapLUT(bmp1.Height, bmp1.Width, data1.Scan0);
                    bmp1.UnlockBits(data1);
                    return bmp1;
                }).ContinueWith(x =>
                {
                    // assign
                    pictureBox2.Image = x.Result;
                    int newBrightness = bright_tbr.Value;
                    int newContrast = contrast_tbr.Value;
                    // If the value has changed in the meantime, update again
                    if (newBrightness != brightness || newContrast != contrast)
                    {
                        UpdateBitmap();
                    }
                    else
                    {
                        _runningTask = null;
                    }
                }, CancellationToken.None, TaskContinuationOptions.None, ui);
            }
        }
