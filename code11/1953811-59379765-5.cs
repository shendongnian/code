    // crop the image, without resizing
    private byte[] CropImage(byte[] screenshotBytes, int top)
    {
        Android.Graphics.Bitmap bitmap = Android.Graphics.BitmapFactory.DecodeByteArray(
          screenshotBytes, 0, screenshotBytes.Length);
    
        int viewStartY = (int)(top * 2.8f);
        int viewHeight = (int)(bitmap.Height - (top * 2.8f));
        var navBarXY = getNavigationBarSize(context);
        int viewHeightMinusNavBar = viewHeight - navBarXY.Y;
    
        Android.Graphics.Bitmap crop = Android.Graphics.Bitmap.CreateBitmap(bitmap,
            0, viewStartY,
            bitmap.Width, viewHeightMinusNavBar
            );
    
        bitmap.Dispose();
    
        using MemoryStream stream = new MemoryStream();
        crop.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);
        return stream.ToArray();
    }
