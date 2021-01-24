    private async void MediaPlayer_MediaOpened(MediaPlayer sender, object args)
    {
        await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
        {
            var imgUrl = new Uri("https://image.diyidan.net/post/2015/10/27/LILeAOb3BF8qR8Uz.png");
            var imgUrl1 = new Uri("ms-appx:///Assets/test.png");
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync(imgUrl);
    
            var writeableBmp = new WriteableBitmap(1, 1);
            var image1 = await writeableBmp.FromStream(await response.Content.ReadAsStreamAsync());
            var image2 = await writeableBmp.FromContent(imgUrl1);
    
             
            image1.Blit(new Rect(0, 0, image1.PixelWidth, image1.PixelHeight), image2, new Rect(0, 0, image2.PixelWidth, image2.PixelHeight));
    
            var file = await WriteableBitmapToStorageFile(image1, FileFormat.Png);
          
            SystemMediaTransportControlsDisplayUpdater updater = sender.SystemMediaTransportControls.DisplayUpdater;
            updater.Thumbnail = RandomAccessStreamReference.CreateFromFile(file);
            updater.Update();
        });
    
    }
    private async Task<StorageFile> WriteableBitmapToStorageFile(WriteableBitmap WB, FileFormat fileFormat)
    {
        string FileName = "YourFile.";
        Guid BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
        switch (fileFormat)
        {
            case FileFormat.Jpeg:
                FileName += "jpeg";
                BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
                break;
            case FileFormat.Png:
                FileName += "png";
                BitmapEncoderGuid = BitmapEncoder.PngEncoderId;
                break;
            case FileFormat.Bmp:
                FileName += "bmp";
                BitmapEncoderGuid = BitmapEncoder.BmpEncoderId;
                break;
            case FileFormat.Tiff:
                FileName += "tiff";
                BitmapEncoderGuid = BitmapEncoder.TiffEncoderId;
                break;
            case FileFormat.Gif:
                FileName += "gif";
                BitmapEncoderGuid = BitmapEncoder.GifEncoderId;
                break;
        }
        var file = await Windows.Storage.ApplicationData.Current.TemporaryFolder.CreateFileAsync(FileName, CreationCollisionOption.GenerateUniqueName);
        using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
        {
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoderGuid, stream);
            Stream pixelStream = WB.PixelBuffer.AsStream();
            byte[] pixels = new byte[pixelStream.Length];
            await pixelStream.ReadAsync(pixels, 0, pixels.Length);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)WB.PixelWidth, (uint)WB.PixelHeight,
                96.0,
                96.0,
                pixels);
            await encoder.FlushAsync();
        }
        return file;
    }
    private enum FileFormat
    {
        Jpeg,
        Png,
        Bmp,
        Tiff,
        Gif
    }
    
    
     
