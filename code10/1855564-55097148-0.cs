    public class MyLabel : Label
    {
        static MyLabel()
        {
            ContentProperty.OverrideMetadata(typeof(MyLabel),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnContentChanged)));
        }
        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyLabel lbl = d as MyLabel;
            if (lbl.ContentChanged != null)
            {
                DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs( ContentProperty, e.OldValue, e.NewValue);
                lbl.ContentChanged(lbl, args);
            }
        }
        public event DependencyPropertyChangedEventHandler ContentChanged;
    }
