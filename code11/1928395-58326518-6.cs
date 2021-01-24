    using MyApp.CustomControls;
    using MyApp.iOS.CustomRenderers;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    
    [assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
    namespace MyApp.iOS.CustomRenderers
    {
        public class CustomEditorRenderer: EditorRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
            {
                base.OnElementChanged(e);
                if (Control != null && Element != null) {
                    var element = (CustomEditor)this.Element;
                    if (element.IsPassword) {
                        UITextView uiTextView = (UITextView)Control;
                        uiTextView.SecureTextEntry = true;
                    }
                }
            }
        }
    }
