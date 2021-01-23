        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            FooCollection = new BindingList<Foo>();
            var foo = new Foo("Alpha");
            FooCollection.Add(foo);
 
            foo = new Foo("Beta");
            SelectedFoo = foo;
            FooCollection.Add(foo);
            foo = new Foo("Gamma");
            FooCollection.Add(foo);
        }
        public Foo SelectedFoo
        {
            get { return (Foo)GetValue(SelectedFooProperty); }
            set { SetValue(SelectedFooProperty, value); }
        }
        public static readonly DependencyProperty SelectedFooProperty =
            DependencyProperty.Register("SelectedFoo", typeof(Foo), typeof(MainWindow), new UIPropertyMetadata(null));
        public BindingList<Foo> FooCollection
        {
            get { return (BindingList<Foo>)GetValue(FooCollectionProperty); }
            set { SetValue(FooCollectionProperty, value); }
        }
        public static readonly DependencyProperty FooCollectionProperty =
            DependencyProperty.Register("FooCollection", typeof(BindingList<Foo>), typeof(MainWindow), new UIPropertyMetadata(new BindingList<Foo>()));
