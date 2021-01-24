C#
   public ObservableCollection<string> GalleryStream()
        {
            var gallerySources = new ObservableCollection<string>();
            Android.Net.Uri imageUri = MediaStore.Images.Media.ExternalContentUri;
     
            var cursor = Android.App.Application.Context.ContentResolver.Query(imageUri, null, MediaStore.Images.ImageColumns.MimeType + "=? or " + MediaStore.Images.ImageColumns.MimeType + "=?", new string[] { "image/jpeg", "image/png" }, MediaStore.Images.ImageColumns.DateModified);
            while (cursor.MoveToNext())
            {
                string path = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.ImageColumns.Data));
                gallerySources.Add(path);
            }
            return gallerySources;
        }
iOS - GalleryFetcheriOS
C#
  public ObservableCollection<string> GalleryStream()
        {
            var streamArray = new ObservableCollection<string>();
            PHFetchResult fetchResult = PHAsset.FetchAssets(PHAssetMediaType.Image, null);
            for (int i = 0; i < fetchResult.Count(); i++)
            {
                PHAsset phAsset = (PHAsset)fetchResult[i];
                string fileName = (NSString)phAsset.ValueForKey((NSString)"filename");
                PHImageManager.DefaultManager.RequestImageData(phAsset, null, (data, dataUti, orientation, info) =>
                {
                    var path = (info?[(NSString)@"PHImageFileURLKey"] as NSUrl).FilePathUrl.Path;
                    streamArray.Add(path);
                    
                });
            }
            return streamArray;
        }
Forms interface - IGalleryFetcher
C#
    public interface IGalleryFetcher
    {
        ObservableCollection<string> GalleryStream();
    }
Example usage - ContentPage
C#
  private void GetGallery()
        {
            var imageSources = DependencyService.Get<IGalleryFetcher>().GalleryStream();
            foreach (var imageSource in imageSources)
            {
                //Consider applying a limitation to the amount of images to load
                ImageSource source = ImageSource.FromFile(imageSource);
                //Use the image source for your view
            }
