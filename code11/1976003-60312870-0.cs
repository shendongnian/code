     [assembly: ExportRenderer(typeof(MyFrame), typeof(MyFrameRenderer))]
    namespace GradientBorder.Droid
    {
     public class MyFrameRenderer : VisualElementRenderer<Frame>
       {
        public MyFrameRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            
            SetBackgroundResource(Resource.Drawable.Gradient);
        }
      }
    }
