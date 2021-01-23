    public partial class MyDataGridView : IMyListView
    {
        public MyDataGridView()
        {
          InitializeComponent();
        }
    
        public MyDataGridView(MyListViewModel viewModel)
        {
          InitializeComponent();
    
          DataContext = viewModel;
     }
    }
