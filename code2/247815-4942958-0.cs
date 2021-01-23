    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            List<List<String>> data = GetData();
            var grid = CreateGrid(data.Count, data.First().Count());
            PopulateGrid( grid, data );
            this.Content = grid;            
        }
        private void PopulateGrid(Grid grid, List<List<string>> data)
        {
            int rowNumber = 0;
            foreach (var rowContents in data)
            {
                int colNumber = 0;
                foreach (var colValue in rowContents)
                {
                    var tb = new TextBlock { Text = colValue, HorizontalAlignment = HorizontalAlignment.Center, Margin=new Thickness(5) };
                    Grid.SetRow(tb, rowNumber);
                    Grid.SetColumn(tb, colNumber);
                    grid.Children.Add(tb);
                    colNumber++;
                }
                rowNumber++;
            }
        }
        private List<List<string>> GetData()
        {
            return new List<List<String>>() 
            {
                new List<String>( ) { "Date",  "Hyatt Regency",  "Ritz Carlton", "Holiday Inn" },
                new List<String>( ) { "",  "16",  "10", "5" },
                new List<String>( ) { "12/16",  "20%",  "12%", "10%" },
                new List<String>( ) { "",  "",  "", "" },
                new List<String>( ) { "",  "10",  "5", "4" },
                new List<String>( ) { "12/17",  "2%",  "3%", "1%" },
            };
        }
        private Grid CreateGrid(int rows, int cols)
        {
            var grid = new Grid();
            for (int r = 0; r < rows; r++)
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            for (int c = 0; c < rows; c++)
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            return grid;
        }
    }
