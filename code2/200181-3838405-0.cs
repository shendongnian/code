    public void Multiply(Bitmap srcA, Bitmap srcB, Rectangle roi)
        {
            BitmapData dataA = SetImageToProcess(srcA, roi);
    		BitmapData dataB = SetImageToProcess(srcB, roi);
    
            int width = dataA.Width;
            int height = dataA.Height;
            int offset = dataA.Stride - width;
    
            unsafe
            {
                byte* ptrA = (byte*)dataA.Scan0;
    			byte* ptrB = (byte*)dataB.Scan0;
    
                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x, ++ptrA, ++ptrB)
    				{
    					int result = ptrA[0] * ( (ptrB[0] / 255) + 1);
    					ptrA[0] = result > 255 ? 255 : (byte)result;
    				}
                    ptrA += offset;
    				ptrB += offset;
                }
            }
            srcA.UnlockBits(dataA);         
    		srcB.UnlockBits(dataB);         
        }
    
        static public BitmapData SetImageToProcess(Bitmap image, Rectangle roi)
        {
            if (image != null)
                return image.LockBits(
                    roi,
                    ImageLockMode.ReadWrite,
                    image.PixelFormat);
    
            return null;
        }
