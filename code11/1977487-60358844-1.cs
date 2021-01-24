        public HomeUserControl()
        {
            InitializeComponent();
            try
            {
                var newsData = GetPublications(); 
				this.DataContext = newsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
