        static GifImage()
        {
            SourceProperty.OverrideMetadata(typeof(Image), new FrameworkPropertyMetadata(new PropertyChangedCallback(SourcePropertyChanged)));
 
        }
 
        private static void SourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            MessageBox("new source property");
        }
