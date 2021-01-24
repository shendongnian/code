     class VideoPlayerRenderer : ViewRenderer<VideoPlayer, Android.Widget.RelativeLayout>,MediaPlayer.IOnErrorListener
     {
        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> e)
        {
             ....
             videoView.SetOnErrorListener(this);
        }
        public bool OnError(MediaPlayer mp, [GeneratedEnum] MediaError what, int extra)
        {
            return true;
        }
     }
