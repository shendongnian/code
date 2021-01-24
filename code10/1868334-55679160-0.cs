    using Sitecore.Resources.Media;
        
    public static string AbsoluteMediaItemUrl(this Sitecore.Data.Items.MediaItem item)
                {
                    MediaUrlOptions mediaUrlOptions = new MediaUrlOptions
                    {
                        AlwaysIncludeServerUrl = true,
                        AbsolutePath = true
                    };
                    return MediaManager.GetMediaUrl(item, mediaUrlOptions);
                }
