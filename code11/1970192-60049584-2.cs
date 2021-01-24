    [assembly: ExportRenderer(typeof(GradientColorView), typeof(GradientColorViewRenderer))]
    namespace App18.iOS
    {
      public class GradientColorViewRenderer : VisualElementRenderer<BoxView>
      {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientColorView stack = (GradientColorView)this.Element;
            CGColor startColor = stack.StartColor.ToCGColor();
            CGColor midOneColor = stack.MidOneColor.ToCGColor();
            CGColor midTwoColor = stack.MidTwoColor.ToCGColor();
            CGColor endColor = stack.EndColor.ToCGColor();
            #region for Vertical Gradient
            var gradientLayer = new CAGradientLayer();
            #endregion
            #region for Horizontal Gradient
            //var gradientLayer = new CAGradientLayer()
            //{
            //  StartPoint = new CGPoint(0, 0.5),
            //  EndPoint = new CGPoint(1, 0.5)
            //};
            #endregion
            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] { startColor,midOneColor,midTwoColor,endColor
        };
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
      }
    }
