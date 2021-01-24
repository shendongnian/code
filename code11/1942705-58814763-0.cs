using Xamarin.Forms;
namespace xxx
{
    public class GradientColorFrame:Frame
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
    }
}
###in iOS
using xxx;
using xxx.iOS;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(GradientColorFrame), typeof(MyFrameRenderer))]
namespace xxx.iOS
{
    public class MyFrameRenderer : FrameRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientColorFrame stack = (GradientColorFrame)this.Element;
            CGColor startColor = stack.StartColor.ToCGColor();
            CGColor endColor = stack.EndColor.ToCGColor();      
            var gradientLayer = new CAGradientLayer();
            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] { startColor, endColor};
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}
### in Android
using System;
using Android.Content;
using xxx;
using xxx.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(GradientColorFrame), typeof(MyFrameRenderer))]
namespace xxx.Droid
{
    public class MyFrameRenderer : FrameRenderer
    {
        public MyFrameRenderer(Context context) : base(context)
        {
        }
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }
        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {
           
           
            var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,  this.StartColor.ToAndroid(),this.EndColor.ToAndroid(),Android.Graphics.Shader.TileMode.Mirror);
            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
           
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as GradientColorFrame;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }
    }
}
### in xaml
<local:GradientColorFrame StartColor="Blue" EndColor="Red" WidthRequest="300" HeightRequest="300">
   //...            
</local:GradientColorFrame>
