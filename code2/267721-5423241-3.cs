    public class jonblind : ContentControl
    {
        [Category("jonblind")]
	    public bool IsContentVisible
	    {
	        get { return (bool)GetValue(IsContentVisibleProperty); }
	        set { SetValue(IsContentVisibleProperty, value); }
	    }
	    public static readonly DependencyProperty IsContentVisibleProperty = DependencyProperty.Register("IsContentVisible", typeof(bool), typeof(jonblind),
	        new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsOverlayContentVisibleChanged)));
	    private static void OnIsOverlayContentVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	    {
	        jonblind blind = d as jonblind;
	        if(blind != null)
	            SetVisibility(blind);
	    }
	    private static void SetVisibility(jonblind blind)
	    {
	        blind.blindGrid.Visibility = blind.IsContentVisible ? Visibility.Visible : Visibility.Hidden;
	    }
    }
