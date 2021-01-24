        private async Task SaveToFileAsync(byte[] byteList, int width, int height, IStorageFile file)
        {
            using (var stream = (await file.OpenStreamForWriteAsync()).AsRandomAccessStream())
            {
                await ByteToPng(byteList, width, height, stream);
            }
        }
        private async Task ByteToPng(byte[] byteList, int width, int height, IRandomAccessStream file)
        {
            try
            {
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, file);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint) width, (uint) height, 96,
                    96, byteList);
                await encoder.FlushAsync();
            }
            catch (Exception e)
            {
            }
        }
