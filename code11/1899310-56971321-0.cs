    [assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
    namespace Projecro_3.Droid
    {
        public class CustomEntryRenderer : EntryRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);
    
                if (Control != null)
                {
                    GradientDrawable gd = new GradientDrawable();
                    gd.SetColor(global::Android.Graphics.Color.Transparent);
                    this.Control.SetBackgroundDrawable(gd);
                    this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);                  
                }
            }
        }
    }
