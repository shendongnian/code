    class MyClass : INotifyPropertyChanged
    {
        /// <summary>
        /// Event raised when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the property changed event
        /// </summary>
        /// <param name="e">The arguments to pass</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        /// <summary>
        /// Notify for property changed
        /// </summary>
        /// <param name="name">Property name</param>
        protected void NotifyPropertyChanged(string name)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(name));
        }
        /// <summary>
        /// The parent container object
        /// </summary>
        public Container Parent { get; set; }
        // Some data
        int x;
    }
    class Container : DependencyObject
    {
        public static readonly DependencyProperty MyClassProperty = DependencyProperty.Register("MyClass", typeof(MyClass), typeof(Container), new FrameworkPropertyMetadata(MyClassPropChanged));
        public MyClass MyClass
        {
            get { return (MyClass)GetValue(MyClassProperty); }
            set { SetValue(MyClassProperty, value); }
        }
        void MyClassPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Container ct = d as Container;
            if (ct == null)
                return;
            MyClass oldc = e.OldValue as MyClass;
            if (oldc != null)
            {
                oldc.PropertyChanged -= new PropertyChangedEventHandler(MyClass_PropertyChanged);
                oldc.Parent = null;
            }
            MyClass newc = e.NewValue as MyClass;
            if (newc != null)
            {
                newc.Parent = ct;
                newc.PropertyChanged += new PropertyChangedEventHandler(MyClass_PropertyChanged);
            }
        }
        void MyClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MyClass mc = sender as MyClass;
            if (mc == null || mc.Parent == null)
                return;
            mc.Parent.InvalidateProperty(Container.MyClassProperty);
        }
    }
