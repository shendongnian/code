    [assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
    namespace XamarinForms.iOS.CustomRenderer
    {
        public class HtmlLabelRenderer : LabelRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
                if (e.NewElement is HtmlLabel element)
                {
                    var nsAttr = new NSAttributedStringDocumentAttributes
                    {
                        DocumentType = NSDocumentType.HTML
                    };
                    var html = NSData.FromString(element.Text, NSStringEncoding.Unicode);
                    var nsError = new NSError();
                    Control.AttributedText = new NSAttributedString(html, nsAttr, ref nsError);
                }
            }
        }
    }
