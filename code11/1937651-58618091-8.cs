    using System;
    using Android.Content;
    using Android.Graphics;
    using Android.Graphics.Drawables;
    using YourNameSpace;
    using YourNameSpace.Droid;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    [assembly: ExportRenderer(typeof(GradientView),typeof(GradientViewRenderer))]
    namespace YourNameSpace.Droid
    {
        public class GradientViewRenderer : BoxRenderer
        {
            public GradientViewRenderer(Context context) : base(context)
            {
            }
            protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
            {
                base.OnElementChanged(e);
                if (e.NewElement != null)
                {
                    GradientView formsGradientView = Element as GradientView;
                    int[] colors = {
                       Convert.ToInt32(formsGradientView.StartColor.ToHex().Replace("#", "0x"), 16),
                       Convert.ToInt32(formsGradientView.MiddleColor.ToHex().Replace("#", "0x"), 16),
                       Convert.ToInt32(formsGradientView.EndColor.ToHex().Replace("#", "0x"), 16)
                    };
                    var gradeDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight, colors);
                    ViewGroup.SetBackgroundDrawable(gradeDrawable);
                }
            }
        }
    }
