    public static DependencyProperty ImageSourceProperty = 
	DependencyProperty.Register("ImageSource", typeof(String), typeof(MediaItemControl), 
		new PropertyMetadata(delegate(DependencyObject sender, DependencyPropertyChangedEventArgs args)
				{
					(sender as MediaItemControl).ContentImage.Source = new BitmapImage(new Uri((string)args.NewValue, UriKind.RelativeOrAbsolute));
				}));
