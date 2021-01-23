        public UserControl1()
        {
            InitializeComponent();
            this.Controls.Add(myStaticGridView);
            myStaticGridView.Dock = DockStyle.Fill;
        }
        static DataGridView _staticGrid;
        public DataGridView myStaticGridView
        {
            get
            {
                if (_staticGrid != null)
                    return _staticGrid;
                _staticGrid = new DataGridView();
                _staticGrid.Columns.Add("A", "A");
                _staticGrid.Columns.Add("B", "B");
                _staticGrid.Columns.Add("C", "C");
                _staticGrid.Columns[0].DataPropertyName = "A";
                _staticGrid.Columns[1].DataPropertyName = "B";
                _staticGrid.Columns[2].DataPropertyName = "C";
                _staticGrid.DataSource = new[] {
                    new { A = "someA", B = "someB", C = "someC"},
                    new { A = "someA", B = "someB", C = "someC"},
                    new { A = "someA", B = "someB", C = "someC"},
                    new { A = "someA", B = "someB", C = "someC"},
                };
                return _staticGrid;
            }
        }
