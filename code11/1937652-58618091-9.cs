    using System;
    using CoreAnimation;
    using CoreGraphics;
    using YourNameSpace;
    using YourNameSpace.iOS;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    [assembly: ExportRenderer(typeof(GradientView), typeof(GradientViewRenderer))]
    namespace YourNameSpace.iOS
    {
        public class GradientViewRenderer : BoxRenderer
        {
            public override void Draw(CGRect rect)
            {
                //base.Draw(rect);
                GradientView formsGradientView = Element as GradientView;
                var currentContext = UIGraphics.GetCurrentContext();
                currentContext.SaveState();
                var colorSpace = CGColorSpace.CreateDeviceRGB();
                var startColor = formsGradientView.StartColor;
                var startColorComponents = startColor.ToCGColor().Components;
                var middleColor = formsGradientView.MiddleColor;
                var middleColorComponents = middleColor.ToCGColor().Components;
                var endColor = formsGradientView.EndColor;
                var endColorComponents = endColor.ToCGColor().Components;
                nfloat[] colorComponents = {
                    startColorComponents[0], startColorComponents[1], startColorComponents[2], startColorComponents[3],
                    middleColorComponents[0], middleColorComponents[1], middleColorComponents[2], middleColorComponents[3],
                    endColorComponents[0], endColorComponents[1], endColorComponents[2], endColorComponents[3]
                };
                nfloat[] locations = { 0f, 0.5f, 1f };
                var gradient = new CGGradient(colorSpace, colorComponents, locations);
                var startPoint = new CGPoint(0, NativeView.Bounds.Height);
                var endPoint = new CGPoint(NativeView.Bounds.Width, NativeView.Bounds.Height);
                currentContext.DrawLinearGradient(gradient, startPoint, endPoint, CGGradientDrawingOptions.None);
                currentContext.RestoreState();
            }
        }
    }
