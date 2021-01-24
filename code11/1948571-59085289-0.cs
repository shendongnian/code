    [assembly: ExportRenderer(typeof(Picker), typeof(TitledMaterialPickerRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
    namespace VisualDemos.iOS
    {
        public class TitledMaterialPickerRenderer : MaterialPickerRenderer
        {
    
            protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged(e);
                if (Control != null)
                {
                    Control.Underline.Layer.BorderColor = UIColor.Clear.FromHex(0x46433E).CGColor;
                    Control.Underline.Layer.BorderWidth = 1;
                }
            }
        }
    
        public static class UIColorExtensions
        {
            public static UIColor FromHex(this UIColor color, int hexValue)
            {
                return UIColor.FromRGB(
                    (((float)((hexValue & 0xFF0000) >> 16)) / 255.0f),
                    (((float)((hexValue & 0xFF00) >> 8)) / 255.0f),
                    (((float)(hexValue & 0xFF)) / 255.0f)
                );
            }
        }
    }
