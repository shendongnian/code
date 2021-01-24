public class CustomOverlay : ZXingDefaultOverlay
    {
        public CustomOverlay()
        {
            foreach (var child in Children.OfType<BoxView>())
            {
                if (child == Children[2])
                {
                    child.BackgroundColor = StatusColorPalette.Success;
                    Margin = new Thickness(50, 0);
                }
                else
                {
                    child.Opacity = 0;
                }
            }
        }
    }
in Xamal use this 
<Scan:CustomOverlay Grid.Row="1"/>
likewise we can customise the overlay.
