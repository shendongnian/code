    public List<Person> Persons { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            Persons = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                Persons.Add(new Person
                {
                    PersonId = i,
                    FirstName = "FirstName" + i,
                    LastName = "LastName" + i,
                    Position = "Network Administrator " + i
                });
            }
        }
        private PrintHelper _printHelper;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            _printHelper = new PrintHelper(CustomPrintContainer);
            var pageNumber = 0;
            for (int i = 0; i < Persons.Count; i = i + 10)
            {
                var grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                // Static header
                var header = new TextBlock { Text = "Custom Print", Margin = new Thickness(0, 0, 0, 20) };
                Grid.SetRow(header, 0);
                grid.Children.Add(header);
                // Main content with layout from data template
                var dataGrid = new DataGrid();
                dataGrid.AutoGenerateColumns = true;
                dataGrid.ItemsSource = Persons.Skip(i).Take(10);
                Grid.SetRow(dataGrid, 1);
                grid.Children.Add(dataGrid);
                // Footer with page number
                pageNumber++;
                var footer = new TextBlock { Text = string.Format("page {0}", pageNumber), Margin = new Thickness(0, 20, 0, 0) };
                Grid.SetRow(footer, 2);
                grid.Children.Add(footer);
                _printHelper.AddFrameworkElementToPrint(grid);
            }
            _printHelper.OnPrintCanceled += _printHelper_OnPrintCanceled;
            _printHelper.OnPrintFailed += _printHelper_OnPrintFailed;
            _printHelper.OnPrintSucceeded += _printHelper_OnPrintSucceeded;
            var printHelperOptions = new PrintHelperOptions(false);
            printHelperOptions.Orientation = Windows.Graphics.Printing.PrintOrientation.Default;
            printHelperOptions.AddDisplayOption(StandardPrintTaskOptions.Orientation);
            await _printHelper.ShowPrintUIAsync("print sample", printHelperOptions);
        }
