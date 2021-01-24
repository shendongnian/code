    public class LongPressGestureRecognizerFrameRenderer : FrameRenderer
    {
        FrameWithLongPress view;
        public LongPressGestureRecognizerFrameRenderer()
        {
            UILongPressGestureRecognizer uiLongPressGesture = new UILongPressGestureRecognizer(new Action(async () => {
                await view.ScaleTo(0.9, 2000);
                await view.ScaleTo(1, 2000);
            }));
            this.AddGestureRecognizer(uiLongPressGesture);
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
