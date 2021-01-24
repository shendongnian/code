    PHImageRequestOptions options = new PHImageRequestOptions();
    options.ResizeMode = PHImageRequestOptionsResizeMode.Fast;
    options.DeliveryMode = PHImageRequestOptionsDeliveryMode.FastFormat;
    options.Synchronous = true;
    
    var assets = PHAsset.FetchAssets(PHAssetMediaType.Image, null);
    PHImageManager manager = new PHImageManager();
    
    List<UIImage> images = new List<UIImage>();
    foreach (PHAsset asset in assets)
    {
       manager.RequestImageForAsset(asset, PHImageManager.MaximumSize, PHImageContentMode.Default, options,
                                   (image, info) =>
                                   {
                                       images.Add(image);
                                   });
    }
