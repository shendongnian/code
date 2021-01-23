    [TemplatePart(Name="PART_HoverArea", Type=typeof(FrameworkElement))]
    [TemplatePart(Name="PART_Popup", Type=typeof(Popup))]
    public class MegaMenuItem : HeaderedContentControl
    {
        private FrameworkElement hoverArea;
        private Popup popup;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            // Unhook old template
            if (hoverArea != null)
            {
                hoverArea.PreviewMouseUp -= ShowPopupOnMouseDown;
            }
            hoverArea = null;
            popup = null;
            if (Template == null)
                return;
            // Hook up new template
            hoverArea = (FrameworkElement)Template.FindName("PART_HoverArea", this);
            popup = (Popup)Template.FindName("PART_Popup", this);
            if (hoverArea == null || popup == null)
                return;
            hoverArea.PreviewMouseUp += ShowPopupOnMouseDown;
        }
        private void ShowPopupOnMouseDown(object sender, MouseEventArgs e)
        {
            popup.PlacementTarget = hoverArea;
            popup.Placement = PlacementMode.Bottom;
            popup.StaysOpen = false;
            popup.IsOpen = true;
        }
    }
