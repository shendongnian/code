    public static async Task<byte[]> GetBytesForImageAsync(StorageFile mediafile)
    {
            byte[] bts;
            using (var imgSource = await mediafile.GetScaledImageAsThumbnailAsync(ThumbnailMode.VideosView, Constants._thumbnailReqestedSize, ThumbnailOptions.UseCurrentScale))
            {
                if (!(imgSource is null))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        await imgSource.AsStream().CopyToAsync(stream);
                        bts = stream.ToArray();
                        return bts;
                    }
                }
                else
                    return new byte[] { };
            }
    }
