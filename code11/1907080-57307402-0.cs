      DataClasses1DataContext dc = new DataClasses1DataContext();
        public MainPage()
        {
            InitializeComponent();
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var details = (from x in dc.Details
                           select x).ToList();
            comboBox1.ValueMember = "Contact";
            comboBox1.DataSource = details;
            try
            {
                var combocolumn = new DataGridViewComboBoxColumn();
                combocolumn.ValueMember = "Contact";// Column name
                combocolumn.DataSource = details;//Convert.ToString(combocolumn).ToList(); //new string[] {"1","2" };// dc.Details; 
                gvRecord.Columns.Add(combocolumn);
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
          
        }
