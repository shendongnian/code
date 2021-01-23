    public static readonly DependencyProperty FilePathProperty =           DependencyProperty.Register("FilePath", typeof(string), typeof(FileSelectDialog),  new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None,HandleFilePathPropertyChanged));
        private static void HandleFilePathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control= (FileSelectDialog)d;
            control.SomeUIControl.Text= (string)e.NewValue;
        }
