    public List<Client> _clients = new List<Client>();
            private int _index = 0;
    
        public MainPage()
                {
                    InitializeComponent();
                    
                    this.loginContainer.Child = new LoginStatus();
                    this._clients = GetClients();
                    if(_index<this._clients.Count)
                    txtMain.Text = this._clients[_index].Name;
                }
