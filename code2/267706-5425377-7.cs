    public class Foo : DependencyObject, INotifyPropertyChanged
    {
        public Object This
        {
            get { return this; }
        }
        public bool Modified
        {
            get { return (bool)GetValue(ModifiedProperty); }
            set { SetValue(ModifiedProperty, value); }
        }
        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName",
                                        typeof(string),
                                        typeof(Foo),
                                        new UIPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFileNameChanged)));
        
        public static readonly DependencyProperty ModifiedProperty =
            DependencyProperty.Register("Modified",
                                        typeof(bool),
                                        typeof(Foo),
                                        new UIPropertyMetadata(false, new PropertyChangedCallback(OnModifiedChanged)));
        private static void OnFileNameChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Foo foo = obj as Foo;
            foo.OnPropertyChanged("This");
        }
        private static void OnModifiedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Foo foo = obj as Foo;
            foo.OnPropertyChanged("This");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
