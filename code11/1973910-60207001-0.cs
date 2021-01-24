    public ImageButton(HorizontalAlignment hAlignment, VerticalAlignment vAlignment, string filename)
    {
    	Width = 35;
    	Height = 35;
    	Background = Brushes.Transparent;
    	HorizontalAlignment = hAlignment;
    	BorderBrush = Brushes.Transparent;
    	VerticalAlignment = vAlignment;
    	Content = new Image
    	{
    		Source = new BitmapImage(new Uri("pack://application:,,,/Resources/" + filename))
    	};
    }
