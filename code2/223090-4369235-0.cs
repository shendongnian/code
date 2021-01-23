        public string MyCustomProperty
        {
            get 
            { 
                return (string)GetValue(MyCustomPropertyProperty); 
            }
            set 
            { 
                SetValue(MyCustomPropertyProperty, value); 
            }
        }
        // Using a DependencyProperty as the backing store for MyCustomProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCustomPropertyProperty =
            DependencyProperty.Register("MyCustomProperty", typeof(string), typeof(TargetCatalogControl), new UIPropertyMetadata(MyPropertyChangedHandler));
        public static void MyPropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get instance of current control from sender
            // and property value from e.NewValue
            
            // Set public property on TaregtCatalogControl, e.g.
            ((TargetCatalogControl)sender).LabelText = e.NewValue.ToString();
        }
        // Example public property of control
        public string LabelText
        {
            get { return label1.Content.ToString(); }
            set { label1.Content = value; }
        }
