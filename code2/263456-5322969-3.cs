    public void Page_Load(object sender, EventArgs e){
                         InitializeComponent();
                         Person all = new Person();
                         MyGridView.DataSource = all.GetAll();
    }
            
