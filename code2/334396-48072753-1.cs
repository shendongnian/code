    private void LoadPictureBoxWithImage( string ImagePath)
    {
        Stream objInputImageStream = null;
        BitmapData bmdImageData = null;
        Bitmap bmpSrcImage = null, bmTemp = null;
        byte[] arrImageBytes = null;
        int bppModifier = 3;
        try
        {
            objInputImageStream = new MemoryStream();
            using (FileStream objFile = new FileStream(ImagePath, FileMode.Open, FileAccess.Read))
            {
                objFile.CopyTo(objInputImageStream);
            }
            bmpSrcImage = new Bitmap(objInputImageStream);
            bppModifier = bmpSrcImage.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4;
            //reda from byte[] to bitmap               
            bmdImageData = bmpSrcImage.LockBits(new Rectangle(0, 0, bmpSrcImage.Width, bmpSrcImage.Height), ImageLockMode.ReadOnly, bmpSrcImage.PixelFormat);
            arrImageBytes = new byte[Math.Abs(bmdImageData.Stride) * bmpSrcImage.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmdImageData.Scan0, arrImageBytes, 0, arrImageBytes.Length);
            bmpSrcImage.UnlockBits(bmdImageData);
           
            pbSetup.Image = (Bitmap)bmpSrcImage.Clone();
            pbSetup.Refresh();
            
        }
        catch (Exception ex)
        {
            throw new Exception("Error in Function " + System.Reflection.MethodInfo.GetCurrentMethod().Name + "; " + ex.Message);
        }
        finally
        {
            if (objInputImageStream != null)
            {
                objInputImageStream.Dispose();
                objInputImageStream = null;
            }
            if (bmdImageData != null)
            {
                bmdImageData = null;
            }
            if (bmpSrcImage != null)
            {
                bmpSrcImage.Dispose();
                bmpSrcImage = null;
            }
            if (bmTemp != null)
            {
                bmTemp.Dispose();
                bmTemp = null;
            }
            if (arrImageBytes != null)
            {
                arrImageBytes = null;
            }
        }
    }
