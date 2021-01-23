        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ForceSoftwareRendering)
            {
                HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
                HwndTarget hwndTarget = hwndSource.CompositionTarget;
                hwndTarget.RenderMode = RenderMode.SoftwareOnly;
            }
        }
