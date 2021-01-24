            int count = 0;
            while (running)
            {
                using (Image transformedDepth = new Image(ImageFormat.Depth16, colorWidth, colorHeight, colorWidth * sizeof(UInt16)))
                using (Capture capture = await Task.Run(() => { return this.kinect.GetCapture(); }))
                {
                    count++;
                    this.transform.DepthImageToColorCamera(capture, transformedDepth);
                    this.bitmap.Lock();
                    var color = capture.Color;
                    var region = new Int32Rect(0, 0, color.WidthPixels, color.HeightPixels);
                    unsafe
                    {
                        using (var pin = color.Memory.Pin())
                        {
                            this.bitmap.WritePixels(region, (IntPtr)pin.Pointer, (int)color.Size, color.StrideBytes);
                        }
                        if (boundingBox != null)
                        {
                            int y = (boundingBox.Y + boundingBox.H / 2);
                            int x = (boundingBox.X + boundingBox.W / 2);
                            this.StatusText = "The person is:" + transformedDepth.GetPixel<ushort>(y, x) + "mm away";
                        }
                    }
                    this.bitmap.AddDirtyRect(region);
                    this.bitmap.Unlock();
                    if (count % 30 == 0)
                    {
                        var stream = StreamFromBitmapSource(this.bitmap);
                        _ = computerVision.AnalyzeImageInStreamAsync(stream, MainWindow.features).ContinueWith((Task<ImageAnalysis> analysis) =>
                        {
                            try
                            {
                                foreach (var item in analysis.Result.Objects)
                                {
                                    if (item.ObjectProperty == "person")
                                    {
                                        this.boundingBox = item.Rectangle;
                                    }
                                }
                            }
                            catch (System.Exception ex)
                            {
                                this.StatusText = ex.ToString();
                            }
                        }, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                }
            }
        }
