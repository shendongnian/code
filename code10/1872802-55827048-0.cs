       public static BindableProperty NumberProperty = BindableProperty.Create(nameof(Number), typeof(int), typeof(MyView11), null, propertyChanged: OnNumberChanged);
        private static void OnNumberChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var num = (MyView11)bindable;
            num.Number = (int)newValue;
        }
        public static BindableProperty NumberpProperty = BindableProperty.Create(nameof(Numberp), typeof(int), typeof(MyView11), null, propertyChanged: OnNumber1Changed);
        private static void OnNumber1Changed(BindableObject bindable, object oldValue, object newValue)
        {
            var num = (MyView11)bindable;
            num.Numberp = (int)newValue;
        }
        public int Number
        {
            get => (int)GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }
        public int Numberp
        {
            get => Number + 1;
            set => Number = value - 1;
        }
