        public int TestCounter
        {
            get { return (int)GetValue(TestCounterProperty); }
            set { SetValue(TestCounterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TestCounter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TestCounterProperty =
            DependencyProperty.Register("TestCounter", typeof(int), typeof(TestModel), new UIPropertyMetadata(0));
