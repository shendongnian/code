    private void UpdateOverlaySize()
    {
        if (((this.Overlay != null) && (Application.Current != null)) && ((Application.Current.Host != null) && (Application.Current.Host.Content != null)))
        {
            base.Height = Application.Current.Host.Content.ActualHeight;
            base.Width = Application.Current.Host.Content.ActualWidth;
            // ... other code removed
        }
    }
