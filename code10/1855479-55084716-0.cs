       BitmapDrawable bitmapDrawable = ((BitmapDrawable) imageView.Drawable);
        Bitmap bitmap;
        if(bitmapDrawable==null){
            imageView.BuildDrawingCache();
            bitmap = imageView.GetDrawingCache();
            imageView.BuildDrawingCache(false);
        }else
        {
            bitmap = bitmapDrawable .Bitmap;
        }
