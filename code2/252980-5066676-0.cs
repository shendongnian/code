    private class ImageCallbackState
    {
         public UserInfo Friend { get; set; }
         public Action<UserInfo,BitmapImage> Callback { get; set; }
    }
    private void GetProfilePhotosFromServer(IEnumerable<UserInfo> friends)
    {
        Parallel.ForEach(friends, f =>
        {
            //get defualt
            if (f.ProfilePhoto == null) 
                f.ProfilePhotoAsBitmap = CreateDefaultAvatar(f.Sex);
            Action<UserInfo,BitmapImage> action = (u,i) => {
                  i.Freeze();
                  u.ProfilePhotoAsBitMap = i;
            };
            var state = new ImageCallbackState { Friend = f, Callback = action };
            StartDownloadingImage(f.MediumProfilePhoto,state);
        });
    }
    private void StartDownloadingImage(Uri imageUri, ImageCallbackState state)
    {
        _webRequest = WebRequest.Create(imageUri);
        _webRequest.BeginGetResponse(this.ProcessImage, state); // pass callback state
    }
    private void ProcessImage(IAsyncResult asyncResult)
    {
        var response = _webRequest.EndGetResponse(asyncResult);
        using (var stream = response.GetResponseStream())
        {
            var buffer = new Byte[response.ContentLength];
            int offset = 0, actuallyRead = 0;
            do
            {
                actuallyRead = stream.Read(buffer, offset, buffer.Length - offset);
                offset += actuallyRead;
            }
            while (actuallyRead > 0);
            var image = new BitmapImage
            {
                CreateOptions = BitmapCreateOptions.None,
                CacheOption = BitmapCacheOption.OnLoad
            };
            image.BeginInit();
            image.StreamSource = new MemoryStream(buffer);
            image.EndInit();
            var state = asyncResult.AsyncState as ImageCallbackState
            state.Callback(state.Friend,image);
        }
    }
