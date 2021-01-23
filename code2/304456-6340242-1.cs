        private int _index = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            _clients = GetClients();
            txtSelectedName.Text = _clients[_index].Name;
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            _index = _index == 0 ? _clients.Count - 1 : _index - 1;
            txtSelectedName.Text = _clients[_index].Name;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            _index = _index == _clients.Count - 1 ? 0 : _index + 1;
            txtSelectedName.Text = _clients[_index].Name;
        } 
