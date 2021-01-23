    public delegate void BitmapWork(UInt32* ptr, int stride);
        /// <summary>
        /// you don't want to forget to unlock a bitmap do you?  I've made that mistake too many times...
        /// </summary>
        unsafe private void UnlockBitmapAndDoWork(Bitmap bmp, BitmapWork work)
        {
            var s = new Rectangle (0, 0, bmp.Width, bmp.Height); 
            var locker = bmp.LockBits(new Rectangle(0, 0, 320, 200), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            var ptr = (UInt32*)locker.Scan0.ToPointer();
            
            // so many times I've forgotten the stride is expressed in bytes, but I'm accessing with UInt32's.  So, divide by 4.
            var stride = locker.Stride / 4;
            work(ptr, stride);
            bmp.UnlockBits(locker);
        }
        //using System.Drawing.Imaging;
        unsafe private void randomPixels()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            // 32 bits per pixel.  You might need to concern youself with the Alpha part depending on your use of the bitmap
            Bitmap bmp = new Bitmap(300, 200, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            UnlockBitmapAndDoWork(bmp, (ptr, stride) => 
            {
                var calcLength = 300 * 200; // so we only have one loop, not two.  It's quicker!
                for (int i = 0; i < calcLength; i++)
                {
                    // You can use the pointer like an array.  But there's no bounds checking.
                    ptr[i] = (UInt32)r.Next();
                }
            });            
        }
