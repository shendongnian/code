    class MyValidation
    { 
    
        public bool status
            {
                get { return (bool)GetValue(statusProperty); }
                set { SetValue(statusProperty, value); }
            }
        
            public static readonly DependencyProperty statusProperty =
                DependencyProperty.Register("status", typeof(bool), typeof(MyValidation),new PropertyMetadata(false));
}
