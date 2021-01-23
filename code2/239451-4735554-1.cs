    private void ProgressBar_Loaded(object sender, RoutedEventArgs e)
    {
    	var p = (ProgressBar)sender;
    	p.ApplyTemplate();
    
    	((Panel)p.Template.FindName("Animation", p)).Background = Brushes.Red;
    }
