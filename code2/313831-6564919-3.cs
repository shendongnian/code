        public MainWindow()
        {
            InitializeComponent();
            var actions = Observable
                .FromEventPattern<RoutedEventArgs>(actionBn, "Click");
            var firsts = Observable
                .FromEventPattern<RoutedEventArgs>(firstBn, "Click")
                .Select(x => firstBn);
            var seconds = Observable
                .FromEventPattern<RoutedEventArgs>(secondBn, "Click")
                .Select(x => secondBn);
            var buttons = firsts.Merge(seconds);
            var buttonActions = buttons
                .Select(x => actions.Select(_ => x))
                .Switch();
            buttonActions.Subscribe(x => Console.WriteLine(x.Name));
        }
 
