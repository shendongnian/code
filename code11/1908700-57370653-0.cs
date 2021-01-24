    [assembly: Dependency(typeof(AndroidRaiseImage))]
    namespace App18.Droid
    {
      class AndroidRaiseImage : IRaiseImage
       {
         public Stream RaiseImage(Stream stream)
          {
            Bitmap bitmap = BitmapFactory.DecodeStream(stream);
            //raise the bitmap contrast
            ...
            // return the new stream
            MemoryStream ms = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, ms);
            return ms;
          }
       }
    }
