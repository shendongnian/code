    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var random = new Random();
        StorageFolder folder = KnownFolders.PicturesLibrary;
        StorageFile MyOriginalfile = await folder.GetFileAsync("file_example_TIFF_1MB.tiff");
               
        StorageFolder storage = null;
        try
        {
            uint frameCount;
            using (IRandomAccessStream randomAccessStream = await MyOriginalfile.OpenAsync(FileAccessMode.Read, StorageOpenOptions.None))
            {
                Windows.Graphics.Imaging.BitmapDecoder bitmapDecoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(Windows.Graphics.Imaging.BitmapDecoder.TiffDecoderId, randomAccessStream);
                frameCount = bitmapDecoder.FrameCount;
                if (frameCount == 16)
                {
                    StorageFolder mainfolder = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFolderAsync("DynamicFolder");
                    storage = await mainfolder.CreateFolderAsync(String.Format("{0:X6}", random.Next(0x1000000)), CreationCollisionOption.ReplaceExisting);
                }
                if (storage != null)
                {
                    for (int frame = 0; frame < frameCount; frame++)
                    {
                        var bitmapFrame = await bitmapDecoder.GetFrameAsync(Convert.ToUInt32(frame));
                        var softImage = await bitmapFrame.GetSoftwareBitmapAsync();
                        var bmif = await storage.CreateFileAsync($"X{frame}.png", CreationCollisionOption.ReplaceExisting);
                        SaveSoftwareBitmapToFile(softImage, bmif);
                    }
                }
            }
        }
        catch { }
    }
    
    private async void SaveSoftwareBitmapToFile(SoftwareBitmap softwareBitmap, StorageFile outputFile)
    {
        using (IRandomAccessStream stream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            // Create an encoder with the desired format
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
            // Set the software bitmap
            encoder.SetSoftwareBitmap(softwareBitmap);
            encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Fant;
            encoder.IsThumbnailGenerated = true;
            try
            {
                await encoder.FlushAsync();
            }
            catch (Exception err)
            {
                const int WINCODEC_ERR_UNSUPPORTEDOPERATION = unchecked((int)0x88982F81);
                switch (err.HResult)
                {
                    case WINCODEC_ERR_UNSUPPORTEDOPERATION:
                        // If the encoder does not support writing a thumbnail, then try again
                        // but disable thumbnail generation.
                        encoder.IsThumbnailGenerated = false;
                        break;
                    default:
                        throw;
                }
            }
            if (encoder.IsThumbnailGenerated == false)
            {
                await encoder.FlushAsync();
            }
        }
    }
