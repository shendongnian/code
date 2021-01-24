    public partial class NewProductsMenu : ThemedWindow
    {
        public NewProductsMenu()
        {
            InitializeComponent();
            DataContext = NewProductsMenuVM.Instance;
        }
        
        ...
        public void saveToDB()
        {
            string ProductName = NewProductsMenuVM.Instance.ProductName;
        }
    }
