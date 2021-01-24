    class NamedStackLayout:StackLayout
    {
        public string Name { get; set; }
        public static readonly BindableProperty IndexProperty = BindableProperty.Create("Index", typeof(int), typeof(NamedStackLayout), 1);
        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }
    }
