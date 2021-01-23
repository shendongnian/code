    private int hub_page_index;
    protected override void OnOrientationChanged(OrientationChangedEventArgs e)
    {
        base.OnOrientationChanged(e);
        
        if (panorama.Visibility == Visibility.Visible)
        {
            hub_page_index = panorama.SelectedIndex;
        }
        else if (pivot.Visibility == Visibility.Visible)
        {
            hub_page_index = pivot.SelectedIndex;
        }
        
        if (e.Orientation == PageOrientation.Landscape
         || e.Orientation == PageOrientation.LandscapeLeft
         || e.Orientation == PageOrientation.LandscapeRight)
        {
        // Display Pivot in Landscape orientation
            pivot.SetValue(Pivot.SelectedItemProperty, pivot.Items[panorama.SelectedIndex]);
            panorama.Visibility = Visibility.Collapsed;
            pivot.Visibility = Visibility.Visible;
        }
        else
        {
            // Display Panorama in Portrait orientation
            panorama.SetValue(Panorama.SelectedItemProperty, panorama.Items[pivot.SelectedIndex]);
            pivot.Visibility = Visibility.Collapsed;
            panorama.Visibility = Visibility.Visible;
        }
    }
