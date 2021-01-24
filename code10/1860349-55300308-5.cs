    [assembly: Dependency (typeof (Droid.ContentLoader))]
    namespace Droid
    {
        public class ContentLoader : IContentLoader
        {
            public ImageSource LoadFromContentUri(Uri uri)
            {
                var contentResolver = Application.ApplicationContext.ContentResolver;
                var streamImageSource = new StreamImageSource() 
                {
                    Stream = (cancellationToken) => Task.FromResult(contentResolver.OpenInputStream(Android.Net.Uri.Parse(uri.ToString())));
                }
                return streamImageSource;
            }
        }
    }
