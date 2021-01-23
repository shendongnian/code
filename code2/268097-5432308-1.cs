        Control.BackgroundProperty.OverrideMetadata(typeof(MyTextBox), new FrameworkPropertyMetadata(Brushes.Red, 
				FrameworkPropertyMetadataOptions.Inherits, PropertyChangedCallback));
		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			// set breakpoint here
		}
