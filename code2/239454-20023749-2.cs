        public void ProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            var progressBar = sender as ProgressBar;
            if (progressBar == null) return;
            var animation = progressBar.Template.FindName("Animation", progressBar) as FrameworkElement;
            if (animation != null)
                animation.Visibility = Visibility.Collapsed;
        }
