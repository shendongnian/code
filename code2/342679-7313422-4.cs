        static GifImage()
        {
            SourceProperty.OverrideMetadata(typeof(GifImage), new FrameworkPropertyMetadata(new PropertyChangedCallback(SourcePropertyChanged)));
 
        }
 
        private static void SourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            MessageBox("new source property");
        }
