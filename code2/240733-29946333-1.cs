    public sealed class DependencyPropertyListener : DependencyObject, IDisposable
    {
        private static readonly DependencyProperty dummyProperty = DependencyProperty.Register(
            "dummy", 
            typeof(object),
            typeof(DependencyPropertyListener), 
            new PropertyMetadata(null, OnSourceChanged));
        public DependencyPropertyListener(DependencyObject source, DependencyProperty property)
            : this(source, new PropertyPath(property))
        {
        }
        public DependencyPropertyListener(DependencyObject source, string property)
            : this(source, new PropertyPath(property))
        {
        }
        public DependencyPropertyListener(DependencyObject source, PropertyPath property)
        {
            this.Binding = new Binding
            {
                Source = source,
                Path = property,
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            this.BindingExpression = (BindingExpression)BindingOperations.SetBinding(this, dummyProperty, this.Binding);
        }
        public event EventHandler<DependencyPropertyChangedEventArgs> Changed;
        public BindingExpression BindingExpression { get; private set; }
        public Binding Binding { get; private set; }
        public DependencyObject Source
        {
            get { return (DependencyObject)this.Binding.Source; }
        }
        public void Dispose()
        {
            BindingOperations.ClearBinding(this, dummyProperty);
        }
        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DependencyPropertyListener)d).OnChanged(e);
        }
        private void OnChanged(DependencyPropertyChangedEventArgs e)
        {
            var handler = this.Changed;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
