        public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register(
              "DisplayMode", typeof(int), typeof(DisplayModeProperty), new PropertyMetadata(1, OnModeChanged));
 
        public bool DisplayMode
        {
            private get { return (bool)GetValue(DisplayModeProperty); }
            set { SetValue(DisplayModeProperty, value); }
        }
        private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyCustomComponent)d).OnModeChanged(e);
        }
        private void OnModeChanged(DependencyPropertyChangedEventArgs e)
        {
            int mode = Convert.ToInt32(e.NewValue);
			if(mode == 1)
			{
			//... Render for the Mode 1
			}
			else
			{
			//... Render for the Mode 2
			}
           
        }
