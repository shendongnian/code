    [assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
    namespace MedicinalPlants.Droid
    {
        public class HtmlLabelRenderer : LabelRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement is HtmlLabel element)
                    Control.SetText(Html.FromHtml(element.Text), TextView.BufferType.Spannable);
            }
        }
    }
