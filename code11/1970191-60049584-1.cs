    [assembly: ExportRenderer(typeof(GradientColorView), typeof(GradientColorViewRenderer))]
    namespace App18.Droid
    {
      public class GradientColorViewRenderer : VisualElementRenderer<BoxView>
       {
        public GradientColorViewRenderer(Context context) : base(context) { }
        private Color StartColor { get; set; }
        public Color MidOneColor { get; set; }
        public Color MidTwoColor { get; set; }
        private Color EndColor { get; set; }
        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {
            #region for Vertical Gradient
            //var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
            #endregion
            #region for Horizontal Gradient
            var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,new int[] {
                   this.StartColor.ToAndroid(),
                   this.MidOneColor.ToAndroid(),
                   this.MidTwoColor.ToAndroid(),
                   this.EndColor.ToAndroid()},new float[] {0.0f,0.25f,0.75f,1.0f },
            #endregion
                   Android.Graphics.Shader.TileMode.Mirror);
            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var view = e.NewElement as GradientColorView;
                this.StartColor = view.StartColor;
                this.MidOneColor = view.MidOneColor;
                this.MidTwoColor = view.MidTwoColor;
                this.EndColor = view.EndColor;
            }
            catch (Exception ex)
            {
            
            }
        }
     }
    }
