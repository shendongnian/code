    [assembly: ExportRenderer(typeof(myVideoPlayer), typeof(VideoPlayerRenderer))]
    namespace App48.iOS
    {
        public class VideoPlayerRenderer : ViewRenderer<myVideoPlayer, UIView>
        {
            AVPlayer player;
            AVPlayerItem playerItem;
            AVPlayerViewController _playerViewController;       // solely for ViewController property
            AVAsset asset;
    
            NSError err;
    
            public override UIViewController ViewController => _playerViewController;
    
            protected override void OnElementChanged(ElementChangedEventArgs<myVideoPlayer> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement != null)
                {
                    if (Control == null)
                    {
                        // Create AVPlayerViewController
                        _playerViewController = new AVPlayerViewController();
    
                        // Set Player property to AVPlayer
                        player = new AVPlayer();
                        _playerViewController.Player = player;
    
                        // Use the View from the controller as the native control
                        SetNativeControl(_playerViewController.View);
    
                        asset = AVAsset.FromUrl(new NSUrl("https://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"));
                        if (asset != null)
                        {
                            string[] keys = { "playable" , "hasProtectedContent" };
    
                            asset.LoadValuesAsynchronously(keys, () =>
                            {
                                DispatchQueue.MainQueue.DispatchAsync(() =>
                                {
                                    // Device.BeginInvokeOnMainThread(() => { 
                                    if (asset == null) return;
    
                                    Console.WriteLine(asset.StatusOfValue("playable", out err));
    
                                    playerItem = new AVPlayerItem(asset);
                                    player.ReplaceCurrentItemWithPlayerItem(playerItem);
                                    if (playerItem != null)
                                        player.Play();
                                });
                            });
                        }
                    }
                }
            }
    
        }
    }
