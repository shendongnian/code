c#
    //Load a bitmap in memory from file. Size is 1896 x 745, 
    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(@"...");
    //Start a stopwatch to measure performance.
    Stopwatch watch = new System.Diagnostics.Stopwatch();
    watch.Start();
    //Perform 500 times.
    for (int i = 0; i < 500; i++)
    {
        using (var memory = new MemoryStream())
        {
            bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            memory.Position = 0;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memory;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            
            //testImage is an Image control in the UI.
            testImage.Source = bitmapImage;
        }
    }
    watch.Stop();
    System.Diagnostics.Debug.WriteLine(watch.ElapsedMilliseconds + " ms.");
    //Just one test run of this takes about 7000 ms!!!
This takes ~7 seconds to run.
Then, I run this code:
c#
    //Load a bitmap in memory from file. Size is 1896 x 745, 
    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(@"...");
    //Create the BitmapSource (a WriteableBitmap). 96 is the dpi setting.
    WriteableBitmap writeableBMP =
        new WriteableBitmap(1896, 745, 96, 96, PixelFormats.Pbgra32, null);
    //Start a stopwatch to measure performance.
    Stopwatch watch = new System.Diagnostics.Stopwatch();
    watch.Start();
    //Perform 500 times.
    for (int i = 0; i < 500; i++)
    {
        System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
        //Lock the bits to copy from the bitmap to the image source.
        BitmapData data =
            bmp.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //Prepare the buffer size (System.Drawing.Bitmap specific)
        int bufferSize = rect.Height * data.Stride;
        //Prepare the write rectangle, of course this is the entire image.
        Int32Rect writeRectangle = new Int32Rect(0, 0, 1896, 745);
        //Write the pixels
        writeableBMP.WritePixels(writeRectangle, data.Scan0, bufferSize, data.Stride, 0, 0);
    
        //Unlock the bits, to prepare for another cycle.
        bmp.UnlockBits(data);
        testImage.Source = writeableBMP;   
    }
    watch.Stop();
    System.Diagnostics.Debug.WriteLine(watch.ElapsedMilliseconds + " ms.");
    //Multiple test runs of this take ~300 ms!!!
This second piece of code, in all its glorious sloppiness, executes in ~300 ms. It copies the entire bitmap **in every step**. A 1896 x 745 bitmap, should be relatively average for a screen.
My suggestion to use a `WriteableBitmap` improves the run-time of achieving the same result with the originally posted code by about ~7000/300 > ~20 times in my machine. Would you possibly try this as I have posted it, and let me know if it runs any better for you? Having had exactly the same problem with you (and switching to a `WriteableBitmap` of course), I am hard pressed to believe that it only improves your running time by 1-2%. You may have to share some more details of your UI rendering code, so that I can try to locate other potential bottlenecks.
Of course some overhead is to be expected by the rest of the WPF rendering pipeline, as I am only measuring a critical part of the code (relatively roughly, no less) but, in general, the `WriteableBitmap` is close to "as good as it gets" before you abandon software rendering in WPF for any other rendering engine (e.g. hardware).
(I have received 1 downvote and 1 vote to delete this answer so far)
