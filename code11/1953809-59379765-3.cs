    private byte[] CropImage(byte[] screenshotByteArray, int viewLeft, 
        int viewTop, int viewRight, int viewBottom)
    {
        Android.Graphics.Bitmap bitmap = Android.Graphics.BitmapFactory.DecodeByteArray(
            screenshotByteArray, 0, screenshotByteArray.Length);
    
        Android.Graphics.Bitmap croppedBmp = Android.Graphics.Bitmap.CreateBitmap(
            bitmap.Width, bitmap.Height,
            Android.Graphics.Bitmap.Config.Argb8888);
    
        Android.Graphics.Canvas canvas = new Android.Graphics.Canvas(croppedBmp);
    
        Android.Graphics.Color color = Android.Graphics.Color.Rgb(66, 66, 66);
        Android.Graphics.Paint paint = new Android.Graphics.Paint();
    
        paint.AntiAlias = true;
        canvas.DrawARGB(0, 0, 0, 0);
        paint.Color = color;
    
        Android.Graphics.RectF rect = new Android.Graphics.RectF(
            (int)(viewLeft * 3f),
            (int)(viewTop * 2.8f),
            (int)(viewRight * 3f),
            (int)(viewBottom * 2.8f));
        canvas.ClipOutRect(rect);
        canvas.DrawRect(rect, paint);
        paint.SetXfermode(new Android.Graphics.PorterDuffXfermode(Android.Graphics.PorterDuff.Mode.SrcIn));
        canvas.DrawBitmap(bitmap, 0, 0, paint);
    
        using System.IO.MemoryStream stream = new System.IO.MemoryStream();
        croppedBmp.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);
        return stream.ToArray();
    }
