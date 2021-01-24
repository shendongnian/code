    public class LongPressGestureRecognizerFrameRenderer : FrameRenderer
    {
        FrameWithLongPress view;
    
        [Obsolete]
        public LongPressGestureRecognizerFrameRenderer()
        {
            this.LongClick += async (sender, args) => {
                Toast.MakeText(this.Context, "Long press is activated.", ToastLength.Short).Show();
                await view.ScaleTo(0.9, 2000);
                await view.ScaleTo(1, 2000);
            };
        }
    
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
    
            if (e.NewElement != null)
            {
                view = e.NewElement as FrameWithLongPress;
            }
        }
    }
