            var imageDictionary = new ConcurrentDictionary<DateTime, Bitmap>();
            var screenshotTaker = new System.Timers.Timer(1000);
            screenshotTaker.Elapsed += (sender, e) =>
                                           {
                                               Bitmap bmp = GetScreenshot();
                                               imageDictionary.TryAdd(DateTime.Now, bmp);
                                           };
            var screenshotRemover = new System.Timers.Timer(1000);
            screenshotRemover.Elapsed += (sender, e) =>
                                             {
                                                 RemoveExpiredBitmaps();
                                             };
            screenshotTaker.Start();
            screenshotRemover.Start();
