     protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
            {
              base.OnActivityResult(requestCode, resultCode, data);
              if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
              {
                string imagePath = null;
                Android.Net.Uri uri = data.Data;
                var path = GetPath(uri);
         
                string filename = path.Substring(path.LastIndexOf("/") + 1);
         
        
                // String s = path(selectedImageUri);
                Bitmap bitmap = MediaStore.Images.Media.GetBitmap(ContentResolver, data.Data);
              }
            }
     public string GetPath(Android.Net.Uri uri)
        {
          string path = null;
          String[] projection = { MediaStore.MediaColumns.Data };
          ContentResolver cr = ApplicationContext.ContentResolver;
          var metaCursor = cr.Query(uri, projection, null, null, null);
          if (metaCursor != null)
          {
            try
            {
              if (metaCursor.MoveToFirst())
              {
                path = metaCursor.GetString(0);
              }
            }
            finally
            {
              metaCursor.Close();
            }
           
          }
          return path;
        }
