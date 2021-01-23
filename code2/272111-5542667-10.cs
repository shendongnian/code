        public enum Test
        {
            Foo,
            Bar,
            Baz,
            Bat
        } ;
        public MainWindow()
        {
            InitializeComponent();
        
            var mutexes = Enumerable.Range(0, 4)
                .Select(x => new MutexViewModel 
                   { Text = Enum.GetName(typeof (Test), x) });
            DataContext = new MutexesViewModel(mutexes);
        }
