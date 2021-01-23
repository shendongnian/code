    public partial class Window1 : Window
    {
        private IList<Stock> _stocks;
        private readonly string _connectionString = 
            "data source=.;initial catalog=myDB;integrated security=True";
        private readonly SqlTableDependency<Stock> _dependency;
    
        public Window1()
        {
            this.InitializeComponent();
            this.McDataGrid.ItemsSource = LoadCollectionData();
            this.Closing += Window1_Closing;
    
            var mapper = new ModelToTableMapper<Stock>();
            mapper.AddMapping(model => model.Symbol, "Code");
    
            _dependency = new SqlTableDependency<Stock>(_connectionString, "Stocks", mapper);
            _dependency.OnChanged += _dependency_OnChanged;
            _dependency.OnError += _dependency_OnError;
            _dependency.Start();
        }
    
        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _dependency.Stop();
        }
    
        private void _dependency_OnError(object sender, TableDependency.EventArgs.ErrorEventArgs e)
        {
            throw e.Error;
        }
    
        private void _dependency_OnChanged(
            object sender, 
            TableDependency.EventArgs.RecordChangedEventArgs<Stock> e)
        {
            if (_stocks != null)
            {
                if (e.ChangeType != ChangeType.None)
                {
                    switch (e.ChangeType)
                    {
                        case ChangeType.Delete:
                            _stocks.Remove(_stocks.FirstOrDefault(c => c.Symbol == e.Entity.Symbol));
                            break;
                        case ChangeType.Insert:
                            _stocks.Add(e.Entity);
                            break;
                        case ChangeType.Update:
                            var customerIndex = _stocks.IndexOf(
                                    _stocks.FirstOrDefault(c => c.Symbol == e.Entity.Symbol));
                            if (customerIndex >= 0) _stocks[customerIndex] = e.Entity;
                            break;
                    }
    
                    this.McDataGrid.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
                    {
                        this.McDataGrid.Items.Refresh();
                    }));
                }
            }
        }
    
        private IEnumerable<Stock> LoadCollectionData()
        {
            _stocks = new List<Stock>();
    
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM [Stocks]";
    
                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            var code = sqlDataReader
                                    .GetString(sqlDataReader.GetOrdinal("Code"));
                            var name = sqlDataReader
                                    .GetString(sqlDataReader.GetOrdinal("Name"));
                            var price = sqlDataReader
                                    .GetDecimal(sqlDataReader.GetOrdinal("Price"));
    
                            _stocks.Add(new Stock { Symbol = code, Name = name, Price = price });
                        }
                    }
                }
            }
    
            return _stocks;
        }
