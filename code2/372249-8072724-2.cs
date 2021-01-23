    private string _imageUri;
    private Boolean isMounted
    {
        get
        {
            return Android.OS.Environment.ExternalStorageState.Equals(Android.OS.Environment.MediaMounted);
        }
    }
    public void BtnCameraClick(object sender, EventArgs eventArgs)
    {
          var uri = ContentResolver.Insert(isMounted ? MediaStore.Images.Media.ExternalContentUri
                                  : MediaStore.Images.Media.InternalContentUri, new ContentValues());
         _imageUri = uri.ToString();
          var i = new Intent(MediaStore.ActionImageCapture);
          i.PutExtra(MediaStore.ExtraOutput, uri);
          StartActivityForResult(i, CAPTURE_PHOTO);
    }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok && requestCode == CAPTURE_PHOTO)
            {
              Toast.MakeText(this, string.Format("Image URI is {0}",_imageUri), ToastLength.Short).Show();    
            }
        }
