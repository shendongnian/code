    internal static class ThumbnailPresentationLogic
    {
        public static string GetThumbnailUrl(List<Image> images)
        {
            return GetThumbnailUrl(images,
               new Uri(ImageRetrievalConfiguration.GetConfig().ImageRepositoryName),
               ImageRetrievalConfiguration.MiniDefaultImageFullUrl);
        }
        public static string GetThumbnailUrl(List<Image> images, Uri baseUri,
            string defaultImageFullUrl)
        {
            if (images == null || images.FirstOrDefault() == null)
            {
                return defaultImageFullUrl;
            }
            Image latestImage = (from image in images
                                 orderby image.CreatedDate descending
                                 select image).First();
            Uri fullUrl;
            return 
                Uri.TryCreate(baseUri, latestImage.FileName, out fullUrl)
                    ? fullUrl.AbsoluteUri
                    : defaultImageFullUrl;
        }
    }
