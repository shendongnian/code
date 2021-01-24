    [assembly: ExportRenderer(typeof(SomeApp.CustomRenderers.DialogSelectionItem), typeof(SomeApp.iOS.CustomRenderers.DialogSelectionItemRenderer))]
    namespace SomeApp.iOS.CustomRenderers
    {
        public class DialogSelectionItemRenderer : ViewCellRenderer
        {
            // some customizations
        }
    }
